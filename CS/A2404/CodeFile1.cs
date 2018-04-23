using DevExpress.Xpo;

namespace DXSample {
    public class User : XPObject {
        string name;
        public User() : base() { }
        public User(Session session) : base(session) { }
        public string Name { get { return name; } set { name = value; } }
        [Association("User-Role", typeof(Role))]
        public XPCollection Roles { get { return GetCollection("Roles"); } }
    }

    public class Role : XPObject {
        public Role() : base() { }
        public Role(Session session) : base(session) { }

        string roleName;
        public string RoleName {
            get { return roleName; }
            set { roleName = value; }
        }

        [Association("User-Role", typeof(User))]
        public XPCollection Users {
            get { return GetCollection("Users"); }
        }
    }
}