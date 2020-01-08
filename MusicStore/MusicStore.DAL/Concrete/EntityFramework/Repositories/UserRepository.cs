using MusicStore.CORE.DAL.EntityFramework;
using MusicStore.DAL.Abstract;
using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework
{
    public class UserRepository:EFRepositoryBase<User,MusicStoreDbContext>,IUserDAL
    {
    }
}
