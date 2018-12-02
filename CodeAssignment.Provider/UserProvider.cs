using CodeAssgnment.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Provider
{
    public class UserProvider : IProvider<UserEntity>
    {
        private User ConvertToDBModel(UserEntity u)
        {
            User user = new User();
            user.ForeNames = u.ForeNames;
            user.SurName = u.SurName;
            user.Gender = u.Gender;
            user.CreatedOn = u.CreatedOn;
            user.UpdatedOn = u.UpdatedOn;
            user.MobileNo = u.MobileNo;
            user.Id = u.Id;
            user.Dob = u.Dob;
            user.HomeNo = u.HomeNo;
            user.WorkNo = u.WorkNo;
            return user;
        }

        /// <summary>
        /// Add udate User
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>inserted id</returns>
        public int AddUpdate(UserEntity data)
        {
            User model = ConvertToDBModel(data);
            try
            {
                int UserId = 0;
                using (CodeAssignmentDBEntities db = new CodeAssignmentDBEntities())
                {
                    if (model.Id > 0)
                    {
                        User temp = db.Users.Where(u => u.Id == model.Id).FirstOrDefault();

                        if (temp != null)
                        {
                            temp.ForeNames = model.ForeNames;
                            temp.SurName = model.SurName;
                            temp.WorkNo = model.WorkNo;
                            temp.HomeNo = model.HomeNo;
                            temp.MobileNo = model.MobileNo;
                            temp.Gender = model.Gender;
                            temp.Dob = model.Dob;
                            temp.UpdatedOn = DateTime.UtcNow;
                            db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                    else
                    {
                        model.CreatedOn = DateTime.UtcNow;
                        db.Users.Add(model);
                    }

                    int x = db.SaveChanges();
                    if (x > 0)
                    {
                        UserId = model.Id;
                    }
                }

                return UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>User List</returns>
        public UserEntity Get(int id)
        {
            try
            {
                using (CodeAssignmentDBEntities db = new CodeAssignmentDBEntities())
                {
                    return (from u in db.Users
                            where u.Id == id || id == 0
                            select new UserEntity
                            {
                                ForeNames = u.ForeNames,
                                SurName = u.SurName,
                                Gender = u.Gender,
                                CreatedOn = u.CreatedOn,
                                UpdatedOn = u.UpdatedOn,
                                MobileNo = u.MobileNo,
                                Id = u.Id,
                                Dob = u.Dob,
                                HomeNo = u.HomeNo,
                                WorkNo = u.WorkNo
                            }
                    ).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserEntity> GetAll()
        {
            try
            {
                using (CodeAssignmentDBEntities db = new CodeAssignmentDBEntities())
                {
                    return (from u in db.Users
                            select new UserEntity
                            {
                                ForeNames = u.ForeNames,
                                SurName = u.SurName,
                                Gender = u.Gender,
                                CreatedOn = u.CreatedOn,
                                UpdatedOn = u.UpdatedOn,
                                MobileNo = u.MobileNo,
                                Id = u.Id,
                                Dob = u.Dob,
                                HomeNo = u.HomeNo,
                                WorkNo = u.WorkNo
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
