using System;
using System.Linq;
using System.Linq.Expressions;

namespace Omu.ProDinner.Core.Repository
{
    //作为一个仓库，应该具有一些通用功能
    public interface IRepo<T>
    {
        T Get(int id);  //获取具体的
        IQueryable<T> GetAll();  //获取所有
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);
        T Insert(T o);    //插入
        void Save();    //保存
        void Delete(T o);  //删除
        void Restore(T o);
    }
}