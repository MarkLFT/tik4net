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
        public void ListAllUserGroupsWillNotFail()
        {
            var rnd = new Random();
            string groupName = $"TEST{rnd.Next(999)}";
            var userGroup = new UserManagerUserGroup()
            {
                Name = groupName
            };
            Connection.Save(userGroup);

            var userGroups = Connection.LoadAll<UserManagerUserGroup>().ToList();
            Assert.IsTrue(userGroups.Any(x => x.Name == groupName));

            //Cleanup
            Connection.Delete(userGroup);
        }

        [TestMethod]
        public void AddUserGroupWillNotFail()
        {
            var rnd = new Random();
            string groupName = $"TEST{rnd.Next(999)}";
            var userGroup = new UserManagerUserGroup()
            {
                Name = groupName
            };
            Connection.Save(userGroup);

            var userGroups = Connection.LoadAll<UserManagerUserGroup>().ToList();
            Assert.IsTrue(userGroups.Any(x => x.Name == groupName));

            //Cleanup
            Connection.Delete(userGroup);
        }

        #endregion UserManagerUserGroups

        #region UserManagerUsers

        [TestMethod]
        public void AddSingleUserWillNotFail()
        {
            var rnd = new Random();
            var randomUserName = $"TEST{rnd.Next(999)}";
            var user = new UserManagerUser()
            {
                Name = randomUserName,
                Password = "secretpass",
                Group = "default",
            };

            Connection.Save(user);


            var users = Connection.LoadAll<UserManagerUser>().ToList();
            Assert.IsTrue(users.FirstOrDefault(x => x.Name == randomUserName) != null);

            //Cleanup
            Connection.Delete(user);
        }

        [TestMethod]
        public void UpdateUserWillNotFail()
        {
            var rnd = new Random();
            var randomUserName = $"TEST{rnd.Next(999)}";

            //Create user
            var user = new UserManagerUser()
            {
                Name = randomUserName,
                Group = "default",
                Password = "secretpass",
            };
            Connection.Save(user);

            //Update
            user.Password = "changed";
            Connection.Save(user);

            var users = Connection.LoadAll<UserManagerUser>().ToList();
            Assert.IsTrue(users.FirstOrDefault(x => x.Name == randomUserName).Password == "changed");

            //Cleanup
            Connection.Delete(user);
        }

        [Ignore] //DAF: potentionaly harmfull test
        [TestMethod]
        public void DeleteAllUsersWillNotFail()
        {
            _ = Connection.DeleteAll<UserManagerUser>();

            var users = Connection.LoadAll<UserManagerUser>().Count();

            Assert.IsTrue(users == 0);
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

            var testUser = Connection.LoadAll<UserManagerUser>().FirstOrDefault(x => x.Name == "User for " + groupName);
            Assert.IsTrue(testUser != null && testUser.Group == groupName);

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

        [TestMethod]
        public void ListAllUsersWillReturnDefault()
        {
            var rnd = new Random();
            var randomUserName = $"TEST{rnd.Next(999)}";
            var user = new UserManagerUser()
            {
                Name = randomUserName,
                Password = "secretpass",
                Group = "default",
            };

            Connection.Save(user);

            var users = Connection.LoadAll<UserManagerUser>().ToList();
            Assert.IsTrue(users.FirstOrDefault(x => x.Name == randomUserName) != null);

            //Cleanup
            Connection.Delete(user);
        }

        #endregion UserManagerUsers

        #region UserManagerProfiles

        [TestMethod]
        public void ListAllUserManagerProfilesWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            var profile = new UserManagerProfile()
            {
                Name = profileName
            };
            Connection.Save(profile);

            var profiles = Connection.LoadAll<UserManagerProfile>().ToList();
            Assert.IsTrue(profiles.Any(x => x.Name == profileName));

            //Cleanup
            Connection.Delete(profile);
        }

        [TestMethod]
        public void AddUserManagerProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            var profile = new UserManagerProfile()
            {
                Name = profileName
            };
            Connection.Save(profile);

            var profiles = Connection.LoadAll<UserManagerProfile>().ToList();
            Assert.IsTrue(profiles.Any(x => x.Name == profileName));

            //Cleanup
            Connection.Delete(profile);
        }

        [TestMethod]
        public void UpdateUserManagerProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            var profile = new UserManagerProfile()
            {
                Name = profileName,
                Comment = "Initial comment",
            };
            Connection.Save(profile);

            //Update
            profile.Comment = "Changed Comment";
            Connection.Save(profile);

            var profiles = Connection.LoadAll<UserManagerProfile>().ToList();
            Assert.IsTrue(profiles.FirstOrDefault(x => x.Name == profileName).Comment == "Changed Comment");

            //Cleanup
            Connection.Delete(profile);
        }

        [TestMethod]
        public void DeleteUserManagerProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            var profile = new UserManagerProfile()
            {
                Name = profileName
            };
            Connection.Save(profile);

            // Delete
            Connection.Delete(profile);

            var profiles = Connection.LoadAll<UserManagerProfile>().ToList();
            Assert.IsFalse(profiles.Any(x => x.Name == profileName));

        }

        #endregion UserManagerProfiles

        #region UserManagerProfileLimitations

        [TestMethod]
        public void AddUserManagerProfileLimitationWillNotFail()
        {
            var rnd = new Random();
            string limitationName = $"TEST{rnd.Next(999)}";
            string profileName = $"TEST{rnd.Next(999)}";

            var limitation = new UserManagerLimitation()
            {
                Name = limitationName,
                Comment = "Limitation for profile limitation test",
                RateLimitRx = "1M",
                RateLimitTx = "512k"
            };

            Connection.Save(limitation);

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var profileLimitation = new UserManagerProfileLimitation()
            {
                Limitation = limitationName,
                Profile = profileName
            };

            Connection.Save(profileLimitation);

            var limitations = Connection.LoadAll<UserManagerProfileLimitation>().ToList();
            Assert.IsTrue(limitations.Any(x => x.Limitation == limitationName && x.Profile == profileName));

            //Cleanup
            Connection.Delete(profileLimitation);
            Connection.Delete(profile);
            Connection.Delete(limitation);
        }

        [TestMethod]
        public void UpdateUserManagerProfileLimitationWillNotFail()
        {
            var rnd = new Random();
            string limitationName = $"TEST{rnd.Next(999)}";
            string profileName = $"TEST{rnd.Next(999)}";

            var limitation = new UserManagerLimitation()
            {
                Name = limitationName,
                Comment = "Initial comment"
            };
            Connection.Save(limitation);

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var profileLimitation = new UserManagerProfileLimitation()
            {
                Limitation = limitationName,
                Profile = profileName
            };

            Connection.Save(profileLimitation);


            //Update
            profileLimitation.Comment = "Changed Comment";
            Connection.Save(profileLimitation);

            var profileLimitations = Connection.LoadAll<UserManagerProfileLimitation>().ToList();
            Assert.IsTrue(profileLimitations.FirstOrDefault(x => x.Limitation == limitationName && x.Profile == profileName).Comment == "Changed Comment");

            //Cleanup
            Connection.Delete(limitation);
            Connection.Delete(profile);
            Connection.Delete(profileLimitation);
        }

        [TestMethod]
        public void DeleteUserManagerProfileLimitationWillNotFail()
        {
            var rnd = new Random();
            string limitationName = $"TEST{rnd.Next(999)}";
            string profileName = $"TEST{rnd.Next(999)}";

            var limitation = new UserManagerLimitation()
            {
                Name = limitationName
            };
            Connection.Save(limitation);

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var profileLimitation = new UserManagerProfileLimitation()
            {
                Limitation = limitationName,
                Profile = profileName
            };

            Connection.Save(profileLimitation);

            // Delete
            Connection.Delete(profileLimitation);

            var limitations = Connection.LoadAll<UserManagerProfileLimitation>().ToList();
            Assert.IsFalse(limitations.Any(x => x.Limitation == limitationName && x.Profile == profileName));

            //Cleanup
            Connection.Delete(limitation);
            Connection.Delete(profile);
        }

        [TestMethod]
        public void ListAllUserManagerProfileLimitationsWillNotFail()
        {
            var rnd = new Random();
            string limitationName = $"TEST{rnd.Next(999)}";
            string profileName = $"TEST{rnd.Next(999)}";

            var limitation = new UserManagerLimitation()
            {
                Name = limitationName
            };
            Connection.Save(limitation);

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };
            Connection.Save(profile);

            var profileLimitation = new UserManagerProfileLimitation()
            {
                Limitation = limitationName,
                Profile = profileName
            };
            Connection.Save(profileLimitation);

            var limitations = Connection.LoadAll<UserManagerProfileLimitation>().ToList();
            Assert.IsTrue(limitations.Any(x => x.Limitation == limitationName && x.Profile == profileName));

            //Cleanup
            Connection.Delete(limitation);
            Connection.Delete(profile);
            Connection.Delete(profileLimitation);
        }

        #endregion UserManagerProfileLimitations

        #region UserManagerUserProfiles

        [TestMethod]
        public void AddUserManagerUserProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            string userName = $"TEST{rnd.Next(999)}";

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var user = new UserManagerUser()
            {
                Name = userName
            };
            Connection.Save(user);

            var userProfile = new UserManagerUserProfile()
            {
                Profile = profileName,
                User = userName
            };
            Connection.Save(userProfile);

            var profiles = Connection.LoadAll<UserManagerUserProfile>().ToList();
            Assert.IsTrue(profiles.Any(x => x.Profile == profileName));

            //Cleanup
            Connection.Delete(userProfile);
            Connection.Delete(user);
            Connection.Delete(profile);
        }

        [Ignore] //DAF: Feature not implemented in RouterOS?
        [TestMethod]
        public void UpdateUserManagerUserProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            string userName = $"TEST{rnd.Next(999)}";

            var user = new UserManagerUser()
            {
                Name = userName
            };

            Connection.Save(user);

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var userProfile = new UserManagerUserProfile()
            {
                Profile = profileName,
                User = userName
            };

            Connection.Save(userProfile);

            //Update
            string userName2 = $"TEST{rnd.Next(999)}";

            var user2 = new UserManagerUser()
            {
                Name = userName2
            };

            Connection.Save(user2);

            userProfile.User = userName2;
            Connection.Save(userProfile);

            var profiles = Connection.LoadAll<UserManagerUserProfile>().ToList();
            Assert.IsTrue(profiles.FirstOrDefault(x => x.Profile == profileName).User == userName2);

            //Cleanup
            Connection.Delete(userProfile);
            Connection.Delete(user);
            Connection.Delete(user2);
            Connection.Delete(profile);

        }

        [TestMethod]
        public void DeleteUserManagerUserProfileWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            string userName = $"TEST{rnd.Next(999)}";

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };
            Connection.Save(profile);

            var user = new UserManagerUser()
            {
                Name = userName
            };

            Connection.Save(user);

            var userProfile = new UserManagerUserProfile()
            {
                Profile = profileName,
                User = userName
            };
            Connection.Save(userProfile);

            // Delete
            Connection.Delete(userProfile);

            var profiles = Connection.LoadAll<UserManagerUserProfile>().ToList();
            Assert.IsFalse(profiles.Any(x => x.Profile == profileName));
        }

        [TestMethod]
        public void ListAllUserManagerUserProfilesWillNotFail()
        {
            var rnd = new Random();
            string profileName = $"TEST{rnd.Next(999)}";
            string userName = $"TEST{rnd.Next(999)}";

            var profile = new UserManagerProfile()
            {
                Name = profileName
            };

            Connection.Save(profile);

            var user = new UserManagerUser()
            {
                Name = userName
            };

            Connection.Save(user);

            var userProfile = new UserManagerUserProfile()
            {
                Profile = profileName,
                User = userName
            };

            Connection.Save(userProfile);

            var profiles = Connection.LoadAll<UserManagerUserProfile>().ToList();
            Assert.IsTrue(profiles.Any(x => x.Profile == profileName && x.User == userName));

            //Cleanup
            Connection.Delete(userProfile);
        }

        #endregion UserManagerUserProfiles



    }
}
