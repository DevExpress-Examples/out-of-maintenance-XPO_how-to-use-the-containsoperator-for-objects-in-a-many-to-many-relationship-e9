<!-- default file list -->
*Files to look at*:

* [CodeFile1.cs](./CS/A2404/CodeFile1.cs) (VB: [CodeFile1.vb](./VB/A2404/CodeFile1.vb))
* [Form1.cs](./CS/A2404/Form1.cs) (VB: [Form1.vb](./VB/A2404/Form1.vb))
* [program.cs](./CS/A2404/program.cs) (VB: [program.vb](./VB/A2404/program.vb))
<!-- default file list end -->
# How to use the ContainsOperator for objects in a many-to-many relationship


<p>Suppose we have the following classes:</p><p>[C#]<br />
public class User : XPObject {<br />
    string name;<br />
    public User() : base() {}<br />
    public User(Session session) : base(session) {}<br />
    public string Name { get { return name; }set { name = value; }}<br />
    [Association("User-Role", typeof(Role))]<br />
    public XPCollection Roles { get { return GetCollection("Roles"); }}<br />
}</p><p>public class Role : XPObject {<br />
    public Role() : base () {}<br />
    public Role(Session session) : base(session) {}</p><p>    string roleName;<br />
    public string RoleName {<br />
        get { return roleName; }<br />
        set { roleName = value; }<br />
    }</p><p>    [Association("User-Role", typeof(User))]<br />
    public XPCollection Users {<br />
        get { return GetCollection("Users"); }<br />
    }<br />
}</p><p>and there are two roles: "manager" and "programmer". How to obtain a list of users by their role?<br />
Solution</p><p>You can get all the users:</p><p>[C#]<br />
    XPCollection c = new XPCollection(typeof(User));</p><p>Or just the programmers:</p><p>[C#]<br />
    XPCollection c = new XPCollection(typeof(User),<br />
        new ContainsOperator("Roles", new BinaryOperator("This", programmer)));</p><p>Or just the managers:</p><p>[C#]<br />
    XPCollection c = new XPCollection(typeof(User),<br />
        new ContainsOperator("Roles", new BinaryOperator("This", manager)));</p><p>Or just programmers whose names contain "Smith":</p><p>[C#]<br />
    XPCollection c = new XPCollection(typeof(User),<br />
        new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] {<br />
            new ContainsOperator("Roles", new BinaryOperator("This", programmer)),<br />
            new BinaryOperator("Name", "%Smith%", BinaryOperatorType.Like)})<br />
    );</p><p>Note, XPO just translates the "BinaryOperatorType.Like" to the underlying database's "LIKE" operator and you should use the appropriate patterns ("%", "_", etc) to select the desired objects.</p><p>If you are using MS SQL Server you should be aware of the Case Sensitivity setting of your database server to make sure strings are compared in the right way (case sensitive or insensitive).</p>

<br/>


