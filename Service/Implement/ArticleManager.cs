using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Dao;
using Clover.Domain;

namespace Clover.Service.Implement
{
    public class ArticleManager : GenericManagerBase<Article>, IArticleManager
    {
        public IList<Article> LoadAllByPage(out long total, Guid categoryId, int page, int rows, string order, string sort)
        {
            return ((IArticleRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, categoryId, page, rows, order, sort).ToList();
        }

        public void ViewsAdd(Guid id)
        {
            var repository = (IArticleRepository)this.CurrentRepository;
            var entity = repository.Get(id);
            if (entity == null)
            {
                return;
            }

            entity.ViewCount++;
            repository.Save(entity);
        }

        public IList<Article> LoadAllEnable(Guid categoryId)
        {
            return ((IArticleRepository)(this.CurrentRepository)).LoadAllEnable(categoryId).ToList();
        }
    }
}
