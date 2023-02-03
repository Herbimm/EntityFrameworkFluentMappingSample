using EntityFrameworkFluentMappingSample.Data;
using EntityFrameworkFluentMappingSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkFluentMappingSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();
            ListPostAsync(context, 0 , 25);

        }

        public static List<Post> ListPostAsync(BlogDataContext context,int skip = 0, int take = 25)
        {           

            return context.Posts.AsNoTracking()
                .Skip(skip).Take(take).ToList();

            // PAGINAÇÃO DE DADOS, ELE PEGA 25 e depois mais 25 sem Pular nada pq o skip está 0
            // Recomendado para queries grandes onde tem que pegar pouco a pouco para não travar o sistema.
        }

        public static List<PostWithTagsCount> PostWithTagsCount(BlogDataContext context)
        {
            var posts = context.PostWithTagsCount.ToList();
            return posts;
        }
    }

}





