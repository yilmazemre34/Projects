﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.CORE.DAL.EntityFramework
{
    public class EFSingletonContext<TContext>
       where TContext : DbContext, new()
    {
        private static TContext _context;

        public static TContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }
        }

    }
}
