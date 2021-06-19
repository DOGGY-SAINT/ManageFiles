using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageFiles.Model
{
    public class Const
    {   
        //文件还是目录
        public const bool DIR = true;
        public const bool FILE = false;
        //物理块数量
        public const int BLOCK_COUNT = 256;
        //物理块容量
        public const int BLOCK_SIZE = 1024;
        //位示图BIT_SIZE*BIT_SIZE,16*16=256
        public const int BIT_SIZE = 16;

        public const string SUFFIX = ".file";
    }
}
