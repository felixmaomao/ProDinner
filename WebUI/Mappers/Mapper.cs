using Omu.ValueInjecter;

namespace Omu.ProDinner.WebUI.Mappers
{
    public class Mapper<TEntity, TInput> : IMapper<TEntity, TInput>
        where TEntity : class, new()
        where TInput : new()
    {
        //这边的将实体对象的内容注入到输入对象，是在修改时需要吗？
        public virtual TInput MapToInput(TEntity entity)
        {
            var input = new TInput();
            input.InjectFrom(entity)
                .InjectFrom<NormalToNullables>(entity)
                .InjectFrom<EntitiesToInts>(entity);
            return input;
        }

        //我们所填写的对象认为是TInput对象，真正的实体对象可能属性和填写的稍有一些不同，所以我们获取部分属性，填充入实体对象中
        public virtual TEntity MapToEntity(TInput input, TEntity e)
        {
            e.InjectFrom(input)
               .InjectFrom<IntsToEntities>(input)
               .InjectFrom<NullablesToNormal>(input);
            return e;
        }
    }
}