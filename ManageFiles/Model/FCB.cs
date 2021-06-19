using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ManageFiles.Model;

namespace ManageFiles.Model
{
    public class FCB
    {
        private string name;   //文件名
        private string address;     //文件全路径
        private bool fileType;      //类型，目录/文件
        private int blockIndex;     //块起始地址
        private int blockLength;         //块长度
        private int parent;             //父节点块索引
        private List<int> children;     //子节点块索引

        public FCB(string name, string address, bool type, int index, int length, int parent)
        {
            this.name = name;
            this.address = address;
            this.fileType = type;
            this.blockIndex = index;
            this.blockLength = length;
            this.parent = parent;
            if (fileType == Const.DIR) children = new List<int>();
        }

        public FCB(string data)
        {
            string[] sts = data.Split(' ');
            this.name = sts[0];
            this.address = sts[1];
            this.fileType = Convert.ToBoolean(sts[2]);
            this.blockIndex = Convert.ToInt32(sts[3]);
            this.blockLength = Convert.ToInt32(sts[4]);
            this.parent = Convert.ToInt32(sts[5]);
            if (fileType == Const.DIR) children = new List<int>();
            for (int i = 6; i < sts.Length; i++)
                children.Add(Convert.ToInt32(sts[i]));
        }

        //返回所有子结点
        public List<int> getChildren() { return this.children; }
        //根节点无父结点
        public bool isRoot() { return parent <0; }
        //转换为字符串,带了换行符
        public string toString()
        {
            string res;
            res = name + ' ' + address + ' ' + fileType + ' ' + blockIndex + ' ' + blockLength + ' ' + parent;
            if (fileType == Const.DIR)
                foreach (int child in children) { res += " " + child; }
            res += '\n';
            return res;
        }

        public void addChild(int child) { children.Add(child); }

        public void removeChild(int child) { children.Remove(child); }

        public void setLength(int len) { blockLength=len; }
        //返回索引
        public int getIndex() { return blockIndex; }

        public string getAdd() { return address; }

        public string getName() { return name; }

        public bool getType() { return fileType; }

        public int getLength() { return blockLength; }

        public int getParent() { return parent; }
    }
}
