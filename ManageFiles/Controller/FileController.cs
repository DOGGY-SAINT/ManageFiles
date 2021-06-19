using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ManageFiles.Model;
using ManageFiles.View;

namespace ManageFiles.Controller
{
    //采用FAT表+位示图的方式
    public class FileController
    {
        string fileName;
        //FileStream file;
        private int currentDir;     //当前目录项索引
        private FCB[] FCBs;      //FCB表，存着对应block的fcb,fcb不存，只读取
        private Block[] allData;   //所有数据块，这里就当作内存中的数据块了
        private int[] FAT;          //FAT表,对应着物理块号,以及下一块地址，-1结束
        private bool[,] bits;      //位示图,false表示还没用
        private Dictionary<string, int> openFiles;//打开文件表 (文件路径,文件的第一个物理块号)

        //创建或者读取文件,已经带了后缀，并初始化
        public FileController(string fileName, bool exist)
        {
            bits = new bool[Const.BIT_SIZE, Const.BIT_SIZE];//初始化位示图都为未分配状态
            for (int i = 0; i < Const.BIT_SIZE; i++)
                for (int j = 0; j < Const.BIT_SIZE; j++)
                    bits[i, j] = false;

            FCBs = new FCB[Const.BLOCK_COUNT];

            //FAT中,-1代表结束,其他数字代表下一个物理块指向,所以初始化-2
            FAT = Enumerable.Repeat(-2, Const.BLOCK_COUNT).ToArray();

            //目录区初始化
            //dirArea = new FCB[Const.DIR_BLOCK_COUNT];
            //数据初始化
            allData = new Block[Const.BLOCK_COUNT];
            for (int i = 0; i < Const.BLOCK_COUNT; i++)
                allData[i] = new Block();

            //打开文件表初始化
            openFiles = new Dictionary<string, int>();

            currentDir = -1;


            this.fileName = fileName;

            if (exist) readFromFile();
            else
            {
                //清空流
                //file.Seek(0,SeekOrigin.Begin);
                //file.SetLength(0);
                newFCB("root", Const.DIR);
            }
            //初始化后自动保存
            save();
            //更新界面
        }

        public string getFileName()
        {
            return fileName;
        }
        //返回其对应的下一块
        public int nextBlock(int index)
        {
            return FAT[index];
        }

        public FCB getCurrentDir()
        {
            return FCBs[currentDir];
        }
        //新取一块并指向
        public bool newBlock(int i1)
        {
            int i = findNewBlock();
            if (blockOn(I2xy(i)))
            {
                FAT[i1] = i;
                return true;
            }
            return false;
        }
        //位图中寻找第一个块
        public int findNewBlock()
        {
            foreach (int i in Enumerable.Range(0, Const.BIT_SIZE))
                foreach (int j in Enumerable.Range(0, Const.BIT_SIZE))
                    if (bits[i, j] == false)
                        return xy2I(i, j);
            return -1;
        }

        //二维到索引
        public int xy2I(int x, int y)
        {
            return x * Const.BIT_SIZE + y;
        }
        //索引到二维
        public (int, int) I2xy(int i)
        {
            if (i < 0)
                return (-1, -1);
            return (i / Const.BIT_SIZE, i % Const.BIT_SIZE);
        }
        //块启用，位图设为1
        public bool blockOn((int, int) p)
        {
            if (bits[p.Item1, p.Item2] == true || p.Item1 < 0)
                return false;
            bits[p.Item1, p.Item2] = true;
            return true;
        }
        //块禁用，位图设为0
        public bool blockOff((int, int) p)
        {
            if (bits[p.Item1, p.Item2] == false || p.Item1 < 0)
                return false;
            bits[p.Item1, p.Item2] = false;
            return true;
        }

        public bool blockIsOn(int index)
        {
            return bits[I2xy(index).Item1, I2xy(index).Item2];
        }
        //位示图数据
        public string bitString()
        {
            string str = "";
            foreach (bool i in bits)
            {
                str += i + " ";
            }
            str += '\n';
            return str;
        }
        //FAT数据
        public string FATString()
        {
            string str = "";
            foreach (int i in FAT)
            {
                str += i + " ";
            }
            str += '\n';
            return str;
        }
        //FCB对应的数据
        public string dataString(FCB f)
        {
            return f.toString();
        }
        //链式收回
        public void allocate(int i)
        {
            if (nextBlock(i) >= 0)
                allocate(nextBlock(i));
            FAT[i] = -2;
            FCBs[i] = null;
            bits[I2xy(i).Item1, I2xy(i).Item2] = false;
        }

        public bool writeFCB(FCB f, string input = "")
        {
            string data = dataString(f) + input;
            int index = f.getIndex();
            data = allData[index].write(data);
            while (data.Length != 0)
            {
                //还没有下一块 //给i后面新建一块
                if (nextBlock(index) < 0) newBlock(index);
                index = nextBlock(index);
                //溢出
                if (index < 0)
                    return false;
                data = allData[index].write(data);
            }
            //链式收回
            if (nextBlock(index) >= 0)
                allocate(nextBlock(index));
            FAT[index] = -1;
            resize(f.getIndex());
            return true;
        }
        //重新计算FCB大小
        public void resize(int index)
        {
            FCB fcb = FCBs[index];
            int res = 1;
            while(nextBlock(index)>=0)
            {
                res += 1;
                index = nextBlock(index);
            }
            fcb.setLength(res);
        }
        //保存文件,两个换行
        public bool save()
        {
            //closeFile();
            StreamWriter sw = new StreamWriter(fileName);
            foreach (int i in Enumerable.Range(0, Const.BLOCK_COUNT))
            {
                if (FAT[i] > -2 && bits[I2xy(i).Item1, I2xy(i).Item2])
                    sw.WriteLine("#" + i + " " + FAT[i]);
                if (blockIsOn(i))
                    sw.WriteLine(allData[i].read());
            }
            sw.Close();
            sw.Dispose();
            //openFile();
            return true;
        }

        //新建FCB块
        public bool newFCB(string fileName, bool type)
        {
            int i = findNewBlock();
            if (i < 0)
                return false;
            FCB p;
            if (currentDir == -1)
            {
                p = new FCB(fileName, fileName + "/", type, i, 1, currentDir);
                currentDir = i;
            }
            else
            {
                p = new FCB(fileName, getCurrentDir().getAdd() + fileName + "/", type, i, 1, currentDir);
                getCurrentDir().addChild(i);
            }
            FAT[i] = -1;
            FCBs[i] = p;
            bits[I2xy(i).Item1, I2xy(i).Item2] = true;
            writeFCB(p);
            writeFCB(getCurrentDir());
            return true;
        }

        public List<string> getNames()
        {
            List<string> l = new List<string>();
            foreach (int p in getCurrentDir().getChildren())
                l.Add(FCBs[p].getName());
            return l;
        }

        public void readFromFile()
        {
            readAllData();

            bool[] t;
            //t是true表示还没探索
            t = new bool[Const.BLOCK_COUNT];
            for (int i = 0; i < Const.BLOCK_COUNT; i++)
                t[i] = bits[I2xy(i).Item1, I2xy(i).Item2];
            int tmp;
            string wholeStr = "";
            //读FCB
            for (int i = 0; i < Const.BLOCK_COUNT; i++)
            {
                if (t[i])
                {
                    wholeStr += allData[i].read();
                    tmp = i;
                    t[i] = false;
                    while (nextBlock(i) >= 0)
                    {
                        i = nextBlock(i);
                        t[i] = false;
                        wholeStr += allData[i].read();
                    }
                    i = tmp;
                    //fcb和数据
                    string[] k = wholeStr.Split('\n');
                    FCBs[i] = new FCB(k[0]);
                    wholeStr = "";
                }
            }
            currentDir = 0;
        }

        public FCB[] getFCBs() { return FCBs; }
        //从文件中读取block
        public void readAllData()
        {
            StreamReader sr = new StreamReader(fileName);
            string wholeStr = "";
            string tmp;
            int i = -1;
            while (sr.Peek() != -1)
            {
                int t = sr.Peek();
                tmp = sr.ReadLine();
                if (tmp.Length > 0 && tmp[0] == '#')
                {
                    if (i >= 0)
                    {
                        //移除尾部换行符
                        wholeStr = wholeStr.Remove(wholeStr.Length - 1, 1);
                        if (wholeStr.Length > Const.BLOCK_SIZE)
                            System.Diagnostics.Debug.WriteLine("Overflow");
                        allData[i].write(wholeStr);
                        wholeStr = "";
                    }
                    string[] st = tmp.Substring(1, tmp.Length - 1).Split(' ');
                    i = Convert.ToInt32(st[0]);
                    bits[I2xy(i).Item1, I2xy(i).Item2] = true;
                    FAT[i] = Convert.ToInt32(st[1]);

                }
                else wholeStr += tmp + '\n';
            }
            //移除尾部换行符
            wholeStr = wholeStr.Remove(wholeStr.Length - 1, 1);
            if (wholeStr.Length > Const.BLOCK_SIZE)
                System.Diagnostics.Debug.WriteLine("Overflow");
            allData[i].write(wholeStr);
            wholeStr = "";
            sr.Close();
        }

        public void deleteFile(string name)
        {
            int index = -1;
            //找索引
            foreach (int i in getCurrentDir().getChildren())
            {
                if (FCBs[i].getName() == name)
                {
                    index = i;
                    break;
                }
            }
            deleteFile(index);
        }
        //递归删除
        public void deleteFile(int index)
        {
            FCB fcb = FCBs[index];
            if (fcb.getType() == Const.DIR)
            {
                for (int i = 0; i < fcb.getChildren().Count();)
                {
                    int child = fcb.getChildren()[i];
                    deleteFile(child);
                }
            }
            FCBs[fcb.getParent()].removeChild(index);
            writeFCB(FCBs[fcb.getParent()]);
            List<int> stack;
            stack = new List<int>();
            stack.Add(index);
            while (nextBlock(index) >= 0)
            {
                index = nextBlock(index);
                stack.Add(index);
            }
            for (int i=0; i <stack.Count() ;i++)
                deleteIndex(stack[i]);
        }
        //索引块删除
        public void deleteIndex(int index)
        {
            FAT[index] = -2;
            bits[I2xy(index).Item1, I2xy(index).Item2] = false;
            FCBs[index] = null;
        }
        //返回上级目录
        public void returnDir()
        {
            currentDir = getCurrentDir().getParent();
        }
        //进入下级目录
        public void openDir(string name)
        {
            int index = -1;
            //找索引
            foreach (int i in getCurrentDir().getChildren())
            {
                if (FCBs[i].getName() == name)
                {
                    index = i;
                    break;
                }
            }
            currentDir = index;
        }
        //读取出文件中的数据
        public string readFile(string name)
        {
            int index = -1;
            //找索引
            foreach (int i in getCurrentDir().getChildren())
            {
                if (FCBs[i].getName() == name)
                {
                    index = i;
                    break;
                }
            }

            int tmp = index;
            string wholeStr = "";
            //读FCB
            wholeStr += allData[tmp].read();
            while (nextBlock(tmp) >= 0)
            {
                tmp = nextBlock(tmp);
                wholeStr += allData[tmp].read();
            }
            //fcb和数据
            int ind = wholeStr.IndexOf('\n');
            ind += 1;
            string res = wholeStr.Substring(ind,wholeStr.Length-ind);
            res=res.Replace("\n", "\r\n");
            return res;
        }
    }
}
