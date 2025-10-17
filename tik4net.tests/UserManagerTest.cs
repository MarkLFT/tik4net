using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tik4net.Objects;
using tik4net.Objects.UserManager;

namespace tik4net.tests
{
    [TestClass]
    public class UserManagerTest : TestBase
    {
        #region UserManagerUserGroups
        [TestMethod]
        public void ListAllUserWillNotFail()
        {
            var list = Connection.LoadAll<UserManagerUserGroup>().ToList();
        }


        #endregion

        #region UserManagerUsers
        [TestMethod]
        public void AddSingleUserWillNotFail()
        {
            var rnd = new Random();
            var user = new UserManagerUser()
            {
                Name = $"TEST{rnd.Next(999)}",
                Password = "secretpass",
                Group = "default",
            };

            Connection.Save(user);
        }

        [TestMethod]
        public void UpdateUserWillNotFail()
        {
            var rnd = new Random();

            //Create user
            var user = new UserManagerUser()
            {
                Name = $"TEST{rnd.Next(999)}",
                Group = "default",
                Password = "secretpass",
            };
            Connection.Save(user);

            //Update
            user.Password = "changed";
            Connection.Save(user);

            //Cleanup
            Connection.Delete(user);
        }

        [Ignore] //DAF: potentionaly harmfull test
        [TestMethod]
        public void DeleteAllUsersWillNotFail()
        {
            var users = Connection.DeleteAll<UserManagerUser>();
        }

        [TestMethod]
        public void AddUserWithGroupWillNotFail()
        {
            var rnd = new Random();

            string groupName = $"TEST{rnd.Next(999)}";
            var userGroup = new UserManagerUserGroup()
            {
                Name = groupName
            };
            Connection.Save(userGroup);

            var user = new UserManagerUser()
            {
                Name = "User for " + groupName,
                Group = groupName,
            };
            Connection.Save(user);

            //cleanup
            Connection.Delete(user);
            Connection.Delete(userGroup);
        }

        [Ignore] //DAF: potentionaly harmfull test
        [TestMethod]
        public void DeleteAllUserGroupsWillNotFail()
        {
            var list = Connection.LoadAll<UserManagerUserGroup>();
            Connection.SaveListDifferences(list.Where(l => l.Name == "default" || l.Name == "default-anonymous") /*list with "default" as expected => delete all others*/, list);
        }
        #endregion

    }

}
