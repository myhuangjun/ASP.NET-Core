using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 抽象基类
    /// </summary>
     public abstract class ABSBaseClass
    {
        public abstract void Do();
    }

    /// <summary>
    /// 子类
    /// </summary>
    public class ABSChild : ABSBaseClass
    {
        public override void Do()
        {
            
        }
    }

    /// <summary>
    /// 接口
    /// </summary>
    public interface IBaseInterface
    {
        void Do();
    }
    /// <summary>
    /// 接口的实现
    /// </summary>
    public class IChild:IBaseInterface
    {
        public void Do()
        {

        }
    }


}
