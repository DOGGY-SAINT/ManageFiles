using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageFiles.Model;

namespace ManageFiles.Model
{
    class Block
    {
        private string data; // 存储的数据,这里用string表示一块，字符数不超过size

        public Block()
        { }
        //读块
        public string read()
        {
            return data;
        }
        //写块
        public string write(string data)
        {
            //清空data
            data.Remove(0, data.Length);
            //只写入前SIZE个
            int l = Const.BLOCK_SIZE < data.Length ? Const.BLOCK_SIZE : data.Length;
            this.data = data.Substring(0, l);
            return data.Remove(0, l);
        }
    }
}
