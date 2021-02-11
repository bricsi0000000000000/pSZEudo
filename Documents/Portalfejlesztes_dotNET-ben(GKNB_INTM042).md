# 1. Portálfejlesztés .NET-ben (GKNB_INTM042)

- [1. Portálfejlesztés .NET-ben (GKNB_INTM042)](#1-portálfejlesztés-net-ben-gknb_intm042)
  - [1.1. Web Forms](#11-web-forms)
    - [1.1.1. Mappastruktúra](#111-mappastruktúra)
    - [1.1.2. Hozzáadni új oldalt](#112-hozzáadni-új-oldalt)
    - [1.1.3. Hozzáadni Toolbox-ból elemet](#113-hozzáadni-toolbox-ból-elemet)
    - [1.1.4. Rétegek](#114-rétegek)
    - [1.1.5. Entity framework](#115-entity-framework)
      - [1.1.5.1. What is an Entity in Entity Framework?](#1151-what-is-an-entity-in-entity-framework)
        - [1.1.5.1.1. Scalar Property](#11511-scalar-property)
        - [1.1.5.1.2. Navigation Property](#11512-navigation-property)
          - [1.1.5.1.2.1. Reference Navigation Property](#115121-reference-navigation-property)
          - [1.1.5.1.2.2. Collection Navigation Property](#115122-collection-navigation-property)
    - [1.1.6. Relationships](#116-relationships)
      - [1.1.6.1. One to one](#1161-one-to-one)
      - [1.1.6.2. One to many](#1162-one-to-many)
      - [1.1.6.3. Many to many](#1163-many-to-many)
    - [1.1.7. SQL Data Source](#117-sql-data-source)
    - [1.1.8. Hasznos dolgok](#118-hasznos-dolgok)
    - [1.1.9. Toolbox items](#119-toolbox-items)
    - [1.1.10. Hibák](#1110-hibák)
  - [1.2. MVC](#12-mvc)
    - [1.2.1. Mappastruktúra](#121-mappastruktúra)
    - [1.2.2. Áttérés **C#**-ra](#122-áttérés-c-ra)
    - [1.2.3. `View` kiválasztása](#123-view-kiválasztása)
  - [1.3. WEB API](#13-web-api)
    - [1.3.1.1. Areas](#1311-areas)
    - [1.3.1.2. Verziózás](#1312-verziózás)
  - [1.4. Complett project](#14-complett-project)
    - [1.4.1. Logika](#141-logika)
  - [1.5. Model](#15-model)

- Web Forms
  - könnyű összedobni benne egy kisebb projektet
  - nehéz sokan dolgozni benne
- MVC
  - nehéz összedobni benne egy projektet, **de később megéri**
  - könnyű sokan dolgozni benne
- Web API
  - adatforrás készítése

## 1.1. Web Forms

### 1.1.1. Mappastruktúra

- `App_Data`
  - az **adatforrás**t (lokális, sql) célszerű itt elhelyezni.
- `App_Start`
  - Alkalmazás indításakor szükséges fájloknak metódusait tudjuk itt elhelyezni.
  - `BundleConfig.cs`
    - **bundling minification**
    - azokat a javascript fájlokat **összecsomagoljuk egy csomagba** és ezt egyszer küldjük ki a kliensnek. Ezért csak egyszer kell várni arra hogy betöltődjön. **Egy kérés formájában megy.**
    - Ha készítünk javascript fájlokat, célszerű ide beletenni.
  - `RouteConfig.cs`
    - Egy adott URL lapján **ki** tudjunk **választani** egy **lapot** és **visszaküldeni** a **felhasználónak**.
- `Content`
  - **CSS** fájlok
  - Statikus tartalmak elhelyezése *(képek, letölthető/feltölthető állományok)*
- `fonts`
  - **Betűkészletek**
  - glyphicons
    - Kicsi ikonok, amik betütípusban vannak benne.
    - Ez egyszer töltődik be, nem kell a sok kis ikont egyesével betölteni.
- `Scripts`
  - Javascript fájlok
  - *minification*
- `About.aspx`
- `Contact.aspx`
- `Default.aspx`
  - home pagex
- `favicon.ico`
  - ikon
- `Global.asax`
  - `Application_Start()`
    - Amikor a webszerver **betölti/elindul** a honlap, ez ***egyszer* végrehajtódik**.
- `Site.Master` és `Site.Mobile.Master`
  - Máshogy néz ki mobilon mint asztalon.
  - Az egész **alkalmazás kerete**.
  - Ez dönti el hogy hogy fog kinézni az alkalmazás a legalapvetőbb tekintetben.
  - `<% %>`
    - **Váltás C#** és **HTML** között.
    - Ami **közötte** van, a **szerveren** kell értelmezni.
    - Ami **nincs közötte**, azt a **kliensen**.
  - `<asp:valami></asp:valami>`
- `Web.config`
  - *Olyan mint az App.config desktop alkalmazásnál*.
  - Alkalmazás konfigurációját tartalmazza.
  - Milyen framework, függőségek..

### 1.1.2. Hozzáadni új oldalt

`Add Item` $\rightarrow$ `Web Form with Master Page`

Azért kell a `with Master Page` mert szeretnénk ebbe a keretbe, amit a `Master Page` megcsinál, beletenni a sajátunkat.

Mindent amit meg szeretnénk jeleníteni, egy olyan `ContentPlaceHolderID`-vel rendelkező tag párba kell beletenni, ami a `Master Page`-en említve van. Jelen esetben `MainContent`.

A menü a `Site.Master`-ben található.

### 1.1.3. Hozzáadni Toolbox-ból elemet

- ASP-s

  ```html
  <asp:Button ID="Button1" runat="server" Text="Button" />
  ```

  Egy javascript társaságával fog renderelődni, ezért plusz funkcionalitást kapunk.

- Natív html

  ```html
  <input type="button" value="Teszt" />
  ```

  Kliensen fog renderelődni.

### 1.1.4. Rétegek

Solution -> Add -> New Project -> Class Library.

### 1.1.5. Entity framework

`Solution` $\rightarrow$ `NuGetPackages` $\rightarrow$ `EntityFramework` *`(6.2.0)`*.

> Azért `6.2.0`, mert nálam azzal működött úgy mint a tutorialban.

Konstruktorban megadott `MySqlServerConnString`-et a `Web.config` fájlba kell rakni.

```xml
<connectionStrings>
  <add name="MySqlServerConnString" connectionString="Server=DESKTOP-valami; Initial Catalog=ShoppingDB; Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

`connectionString`-ben a `Server` az a SQL Server Management programból van.

`providerName` a felette lévő `providers`-ben van.

A `defaultConnectionFactory`-ben át kell írni a `type` végét `SqlConnectionFactory`-ra.

A `parameter` `value`-ját pedig erre: `Data Source=DESKTOP-valami\MYSQLSERVER; Integrated Security=True; MultipleActiveResultSets=True`;

```xml
<entityFramework>
  <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework">
    <parameters>
      <parameter value="Data Source=RICSI\SQLEXPRESS\MSSQLSERVER; Integrated Security=True; MultipleActiveResultSets=True"/>
    </parameters>
  </defaultConnectionFactory>
  <providers>
    <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
  </providers>
</entityFramework>
<connectionStrings>
  <add name="MySqlServerConnString" connectionString="Server=RICSI\SQLEXPRESS; Initial Catalog=ShoppingDB; Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

#### 1.1.5.1. What is an Entity in Entity Framework?

An entity in Entity Framework is a class that maps to a database table. This class must be included as a `DbSet<TEntity>` type property in the `DbContext` class. EF API maps each entity to a table and each property of an entity to a column in the database.

```cs
public class Student
{
  public int StudentID { get; set; }
  public string StudentName { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public byte[]  Photo { get; set; }
  public decimal Height { get; set; }
  public float Weight { get; set; }
      
  public Grade Grade { get; set; }
}

public class Grade
{
  public int GradeId { get; set; }
  public string GradeName { get; set; }
  public string Section { get; set; }

  public ICollection<Student> Students { get; set; }
}    
```

The above classes become entities when they are included as `DbSet<TEntity>` properties in a context class (the class which derives from `DbContext`), as shown below.

```cs
public class SchoolContext : DbContext
{
  public SchoolContext()
  {

  }

  public DbSet<Student> Students { get; set; }
  public DbSet<Grade> Grades { get; set; }
}
```

In the above context class, `Students`, and `Grades` properties of type `DbSet<TEntity>` are called entity sets. The `Student`, and `Grade` are entities. EF API will create the `Students` and `Grades` tables in the database, as shown below.

![dbtables-for-entities.png](images/dbtables-for-entities.png)

An Entity can include two types of properties: **Scalar Properties** and **Navigation Properties**.

##### 1.1.5.1.1. Scalar Property

The **primitive type** properties are called scalar properties. Each scalar property maps to a column in the database table which stores an actual data. For example, `StudentID`, `StudentName`, `DateOfBirth`, `Photo`, `Height`, `Weight` are the scalar properties in the `Student` entity class.

```cs
public class Student
{
  // scalar properties
  public int StudentID { get; set; }
  public string StudentName { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public byte[]  Photo { get; set; }
  public decimal Height { get; set; }
  public float Weight { get; set; }
      
  //reference navigation properties
  public Grade Grade { get; set; }
}
```

EF API will create a column in the database table for each scalar property, as shown below.

![dbcolumns-for-scalar-properties.png](images/dbcolumns-for-scalar-properties.png)

##### 1.1.5.1.2. Navigation Property

The **navigation property** represents a **relationship** to another entity.

There are **two** types of navigation properties: **Reference Navigation** and **Collection Navigation**.

###### 1.1.5.1.2.1. Reference Navigation Property

If **an entity includes a property of another entity type**, it is called a Reference Navigation Property. It **points to a single entity** and represents multiplicity of one (1) in the entity relationships.

EF API will create a **ForeignKey** column in the table for the navigation properties that points to a **PrimaryKey** of another table in the database. For example, `Grade` are reference navigation properties in the following `Student` entity class.

```cs
public class Student
{
  // scalar properties
  public int StudentID { get; set; }
  public string StudentName { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public byte[]  Photo { get; set; }
  public decimal Height { get; set; }
  public float Weight { get; set; }
      
  //reference navigation property
  public Grade Grade { get; set; }
}
```

In the database, EF API will create a **ForeignKey** `Grade_GradeId` in the `Students` table, as shown below.

![ref-property-in-dbtable.png](images/ref-property-in-dbtable.png)

###### 1.1.5.1.2.2. Collection Navigation Property

If **an entity includes a property of generic collection of an entity type**, it is called a collection navigation property. It represents multiplicity of many (*).

EF API does not create any column for the collection navigation property in the related table of an entity, but it creates a column in the table of an entity of generic collection. For example, the following `Grade` entity contains a generic collection navigation property `ICollection<Student>`. Here, the `Student` entity is specified as generic type, so EF API will create a column `Grade_GradeId` in the `Students` table in the database.

![col-navigation-dbtable.png](images/col-navigation-dbtable.png)

### 1.1.6. Relationships

#### 1.1.6.1. One to one

As you can see in the above figure, `Student` and `StudentAddress` have a **One-to-One relationship** *(zero or one)*. A student can have only one or zero addresses. Entity framework adds the `Student` reference navigation property into the `StudentAddress` entity and the `StudentAddress` navigation entity into the `Student` entity. Also, the `StudentAddress` entity has both `StudentId` property as `PrimaryKey` and `ForeignKey`, which makes it a one-to-one relationship.

```cs
public partial class Student
{
  public Student()
  {
    this.Courses = new HashSet<Course>();
  }
  
  public int StudentID { get; set; }
  public string StudentName { get; set; }
  public Nullable<int> StandardId { get; set; }
  public byte[] RowVersion { get; set; }
  
  public virtual StudentAddress StudentAddress { get; set; }
}
  
public partial class StudentAddress
{
  public int StudentID { get; set; }
  public string Address1 { get; set; }
  public string Address2 { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  
  public virtual Student Student { get; set; }
}
```

In the above example, the `StudentId` property needs to be `PrimaryKey` as well as `ForeignKey`. This can be configured using Fluent API in the OnModelCreating method of the context class.

#### 1.1.6.2. One to many

The `Standard` and `Teacher` entities have a One-to-Many relationship marked by multiplicity where 1 is for One and * is for Many. This means that `Standard` can have many `Teachers` whereas `Teacher` can associate with only one `Standard`.

To represent this, the `Standard` entity has the collection navigation property `Teachers` *(please notice that it's plural)*, which indicates that one `Standard` can have a collection of `Teachers` *(many teachers)*. And the `Teacher` entity has a `Standard` navigation property *(reference property)*, which indicates that `Teacher` is associated with one `Standard`. Also, it contains the `StandardId` foreign key *(PK in Standard entity)*. This makes it a One-to-Many relationship.

```cs
public partial class Standard
{
  public Standard()
  {
    this.Teachers = new HashSet<Teacher>();
  }
  
  public int StandardId { get; set; }
  public string StandardName { get; set; }
  public string Description { get; set; }
  
  public virtual ICollection<Teacher> Teachers { get; set; }
}

public partial class Teacher
{
  public Teacher()
  {
    this.Courses = new HashSet<Course>();
  }
  
  public int TeacherId { get; set; }
  public string TeacherName { get; set; }
  public Nullable<int> TeacherType { get; set; }
  
  public Nullable<int> StandardId { get; set; }
  public virtual Standard Standard { get; set; }
}
```

#### 1.1.6.3. Many to many

The `Student` and `Course` have a Many-to-Many relationship marked by * multiplicity. It means one `Student` can enroll for many `Courses` and also, one `Course` can be taught to many `Students`.

The database includes the `StudentCourse` joining table which includes the primary key of both the tables *(`Student` and `Course` tables)*. Entity Framework represents many-to-many relationships by not having the entity set *(`DbSet` property)* for the joining table in the CSDL and visual designer. Instead it manages this through mapping.

As you can see in the above figure, the `Student` entity includes the collection navigation property `Courses` and `Course` entity includes the collection navigation property `Students` to represent a many-to-many relationship between them.

The following code snippet shows the `Student` and `Course` entity classes.

```cs
public partial class Student
{
  public Student()
  {
    this.Courses = new HashSet<Course>();
  }
  
  public int StudentID { get; set; }
  public string StudentName { get; set; }
  public Nullable<int> StandardId { get; set; }
  public byte[] RowVersion { get; set; }
  
  public virtual ICollection<Course> Courses { get; set; }
}
    
public partial class Course
{
  public Course()
  {
    this.Students = new HashSet<Student>();
  }
  
  public int CourseId { get; set; }
  public string CourseName { get; set; }
  public System.Data.Entity.Spatial.DbGeography Location { get; set; }
  
  public virtual ICollection<Student> Students { get; set; }
}
```

**Note**: Entity framework supports many-to-many relationships only when the joining table *(`StudentCourse` in this case)* does **NOT include any columns other than PKs of both tables**. If the join tables contain additional columns, such as `DateCreated`, then the EDM creates an entity for the middle table as well and you will have to manage CRUD operations for many-to-many entities manually.

Open EDM in XML view. You can see that SSDL *(storage schema)* has the `StudentCourse` entityset, but CSDL doesn't have it. Instead, it's being mapped in the navigation property of the `Student` and `Course` entities. MSL *(C-S Mapping)* has mapping between `Student` and `Course` put into the `StudentCourse` table in the `<AssociationSetMapping/>` section.

![entityrelation3.png](images/entityrelation3.png)

Thus, a many-to-many relationship is being managed by C-S mapping in EDM. So, when you add a `Student` in a `Course` or a `Course` in a `Student` entity and when you save it, it will then insert the PK of the added student and course in the `StudentCourse` table. So, this mapping not only enables a convenient association directly between the two entities, but also manages querying, inserts, and updates across these joins.

### 1.1.7. SQL Data Source

- `Database`
  - Csinálunk egy adatforrást és ez definiál majd egy coonection stringet és egy lekérdezést.
  - Előnye: gyors
  - Hártánya: megkerüljük vele az üzleti logikát

- varázslóból
  - aspx része:

    ```html
    <asp:DropDownList ID="selectedDateDdl1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Date" DataValueField="ShoppingOccasionID"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>" SelectCommand="SELECT [ShoppingOccasionID], [Date] FROM [ShoppingOccasion]"></asp:SqlDataSource>
    ```

  - Web.config része:

    ```html
     <add name="ShoppingDBConnectionString" connectionString="Data Source=RICSI\SQLEXPRESS;Initial Catalog=ShoppingDB;Integrated Security=True"
      providerName="System.Data.SqlClient" />
    ```

- kódból, már a varázsló álltal összekattintottból

  ```cs
    protected void Page_Load(object sender, EventArgs e)
    {
        selectedDateDdl3.DataSource = SqlDataSource2;
        selectedDateDdl3.DataTextField = "Date";
        selectedDateDdl3.DataValueField = "ShoppingOccasionID";
        selectedDateDdl3.DataBind();
    }
  ```

### 1.1.8. Hasznos dolgok

Az `aspx` file-t lenyitva, ott van az `aspx.cs` fájl.

A `protected void Page_Load(object sender, EventArgs e)` függvény mindig akkor fut le amikor az oldal betöltődik.

Eseményeknél(pl.: gomb megnyomása), az oldal mindig újratöltődik.

Az `IsPostBack`-el tudjuk lekezelni, hogy betöltöttük e már az oldalt.

```cs
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        DropDownList1.Items.Add(new ListItem("a", "a"));
        DropDownList1.Items.Add(new ListItem("b", "b"));
        DropDownList1.Items.Add(new ListItem("c", "c"));
        DropDownList1.Items.Add(new ListItem("d", "d"));
    }
}
```

### 1.1.9. Toolbox items

- `asp:Literal`
  - Szöveget lehet bele rakni.
  - Neki `Text`-je van.

### 1.1.10. Hibák

- The type DateTime is defined in an assembly that is not referenced. you must add a reference to assembly
  - megoldás: Web.config-ba ezt bele kell írni:

  ```html
  <compilation debug="true" targetFramework="4.8" >
    <assemblies>
      <add assembly="netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"/>
    </assemblies>
  </compilation>
  ```

## 1.2. MVC

### 1.2.1. Mappastruktúra

- `App_Start`
  - Alkalmazás indításakor szükséges fájloknak metódusait tudjuk itt elhelyezni.
  - `BundleConfig.cs`
    - **bundling minification**
    - azokat a javascript fájlokat **összecsomagoljuk egy csomagba** és ezt egyszer küldjük ki a kliensnek. Ezért csak egyszer kell várni arra hogy betöltődjön. **Egy kérés formájában megy.**
    - Ha készítünk javascript fájlokat, célszerű ide beletenni.
  - `RouteConfig.cs`
    - Egy adott URL lapján **meg** tudjuk **mondani** hogy melyik metódust kell meghívni.

Ami más itt az MVC(Model View Controller)-ben:

- `Controllers`
  - megjelenítési és működési logikát fognak tartalmazni.
  - Controllereket a `Controllers` mappába rakjuk és `*Controller` elnevezéssel látjuk el.
- `Models`
  - osztályok lesznek
- `Views`
  - nézetek

- `Global.asax` fájlban van az `Aplication_Start()` metódus.
  - Ez fut le egyszer az alkalmazás indításakor.
  - Itt hívja meg az `App_Start` mappában található `BundleConfig.cs`, `FilterConfig.cs`, `RouteConfig.cs` fájlokat.
- `AreaRegistration`
  - Egy nagy alkalmazást területekre lehet szabdalni.

A `HomeController`-hez tartozik a `Views` mappában egy `Home` mappa.

Ugyan ezek vannak a `HomeController`-ben.

Browserből jön egy hívás -> a hívás a route-olási szabályoknak megfelelően az elérési utat szétbontja `controller`-re és `action`-re (`url: "{controller}/{action}/{id}"`),

például Home/About, ami a `HomeController`-ben lévő `public ActionResult About()` függvényt hív meg, ami egy `View`-t ad vissza. `return View();`.

---

### 1.2.2. Áttérés **C#**-ra

- `@{ }`
  - ilyenkor a kapcsos zárójelekben lévő utasítások lesznek C#, viszont ha van benn html, akkor azt html-ként értelmezi.
- `@`
  - ilyenkor a mögötte lévő utasítás lesz C#;
  - `<td>@i.ToString() a. oszlop</td>`

---

Át tudok adni a `HomeController`-ből a `cshtml`-nek valamit.

- `HomeController`

  ```cs
   public ActionResult Contact()
   {
       ViewBag.Message = "Your contact page.";
       ViewBag.StudentName = "Én";
       ViewBag.StudentAge = 19;
       ViewBag.StudentBirthDate = new DateTime(2001, 12, 18);
 
       return View();
   }
  ```

- `Contact.cshtml`

  ```html
  <td>@ViewBag.StudentName</td>
  <td>@ViewBag.StudentAge</td>
  <td>@ViewBag.Stud.ToShortDateString()</td>
  ```

  Hozzunk létre egy `Student` osztályt a `Models` mappába, majd a `HomeController`-ben:

- A `Contact.cshtml`-ben pedig:

  ```cs
  ViewBag.Students = new List<Student>()
  {
      new Student(){ID=1, Name="Béla", Age = 12, BirthDate= new DateTime(2002,1,2)},
      new Student(){ID=2, Name="Ádám", Age = 25, BirthDate= new DateTime(1733,5,2)},
      new Student(){ID=3, Name="József", Age = 27, BirthDate= new DateTime(1432,1,7)},
      new Student(){ID=4, Name="Ágnes", Age = 89, BirthDate= new DateTime(2054,7,3)},
      new Student(){ID=5, Name="Zsolt", Age = 54, BirthDate= new DateTime(2078,1,5)},
  };
  ```

  ```html
  @{
    foreach (var student in ViewBag.Students)
    {
        <tr>
            <td>@student.ID.ToString()</td>
            <td>@student.Name<td>
            <td>@student.Age.ToString()</td>
            <td>@student.BirthDate.ToShortDateString()</td>
        </tr>
    }
  }
  ```

---

A `Student` osztályban nem kell lekezelni dolgokat, azt máshol.

Hozzunk létre egy új `View`-t `StudentDetails` néven.

A `Template` legyen `Empty`, a `Model class` pedig a már létrehozott `Student`.

A `View` elején ez a sor jelöli hogy melyik osztályt szeretnénk modellként használni:

```cshtml
@model MVCWebApplication1.Models.Student
```

Létrehozzuk a `HomeController`-ben az új `View` meghívását:

Létre kell hoznunk egy `student`-et és át kell adni a `View`-nak.

Utána a másik oldalon el tudjuk érni a `student` értékeit `@Model.Age`.

```cs
public ActionResult StudentDetails()
{
    var student = new Student() { ID = 6, Name = "Gazsi", Age = 82, BirthDate = new DateTime(1637, 1, 2) };

    return View(student);
}
```

```html
<table>
    <thead>
        <tr>
            <td>Tulajdonság</td>
            <td>Érték</td>
        </tr>
    </thead>
    <tr>
        <td>ID:</td>
        <td>@Model.ID.ToString()</td>
    </tr>
    <tr>
        <td>Name:</td>
        <td>@Model.Name
    </tr>
    <tr>
        <td>Age:</td>
        <td>@Model.Age.ToString()</td>
    </tr>
    <tr>
        <td>Birth date:</td>
        <td>@Model.BirthDate.ToShortDateString()</td>
    </tr>
</table>
```

---

Itt nem `Master.page` van, hanem `Layout`-ok.

Meg lehet adni hogy melyiket használja, ha nem adunk meg akkor ezt használja: `Views/Shared/_Layout.cshtml`

- `_Layout.cshtml`
  - A `@RenderBody()` lesz az, ami a tartalmat megjeleníti.
  - Menü: `<li>@Html.ActionLink("Contact", "Contact", "Home")</li>`
  - `Layout`-ot megadni `View`-nak a `View` létrehozásakor lehet. Alul kell kiválasztani.

---

Hozzunk létre egy `GenericStudentList` nevű `View`-t, aminek a `Template`-je `List`.

Mivel `List` lett a `Template`, ezért létrehozta ezt:

```html
@model IEnumerable<MVCWebApplication1.Models.Student>

@{
    ViewBag.Title = "GenericStudentList";
}

<h2>GenericStudentList</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Age)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.BirthDate)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Age)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.BirthDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.ID }) |
            @Html.ActionLink("Details", "Details", new { id=item.ID }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.ID })
        </td>
    </tr>
}

</table>
```

Ahhoz hogy ez `@model IEnumerable<MVCWebApplication1.Models.Student>` jól megjeleníthető legyen, kell egy felsorolható `Student` lista.

`HomeController`:

```cs
public ActionResult GenericStudentList()
{
    var studentList = new List<Student>()
    {
        new Student(){ID=1, Name="Béla", Age = 12, BirthDate= new DateTime(2002,1,2)},
        new Student(){ID=2, Name="Ádám", Age = 25, BirthDate= new DateTime(1733,5,2)},
        new Student(){ID=3, Name="József", Age = 27, BirthDate= new DateTime(1432,1,7)},
        new Student(){ID=4, Name="Ágnes", Age = 89, BirthDate= new DateTime(2054,7,3)},
        new Student(){ID=5, Name="Zsolt", Age = 54, BirthDate= new DateTime(2078,1,5)},
    };

    return View(studentList);
}
```

Ez megjelenít nekünk egy szép táblázatot automatikusan, viszont a táblázat fejlécébe a változók neveit rakta be.

Ezt megváltoztatni úgy kell, hogy a `Student` osztályban:

```cs
[DisplayName("Név")]
public string Name { get; set; }
```

---

Hozzunk létre a `Models` mappába egy új osztályt `StudentList` néven, amiben van egy `public IEnumerable<Student> Students { get; set; }`

`HomeController`:

```cs
public ActionResult StudentList()
{
    var model = new StudentList();

    var studentList = new List<Student>()
    {
        new Student(){ID=1, Name="Béla", Age = 12, BirthDate= new DateTime(2002,1,2)},
        new Student(){ID=2, Name="Ádám", Age = 25, BirthDate= new DateTime(1733,5,2)},
        new Student(){ID=3, Name="József", Age = 27, BirthDate= new DateTime(1432,1,7)},
        new Student(){ID=4, Name="Ágnes", Age = 89, BirthDate= new DateTime(2054,7,3)},
        new Student(){ID=5, Name="Zsolt", Age = 54, BirthDate= new DateTime(2078,1,5)},
    };

    model.Students = studentList;
    model.MaxAge = studentList.Select(x => x.Age).Max();
    model.MinAge = studentList.Select(x => x.Age).Min();
    model.StudentCount = studentList.Count;

    return View(model);
}
```

Hozzunk létre egy új `View`-t `StudentList` néven. `Template`: `Empty`, `Model class`: `StudentList`.

`StudenList.cshtml`:

```html
<p>
    A legöregebb: @Model.MaxAge <br />
    A legfiatalabb: @Model.MinAge <br />
    A hallgatók száma: @Model.StudentCount <br />
</p>
```

```cs
foreach (var student in Model.Students)
{
  <tr>
      <td>
          @Html.DisplayNameFor(x => student.Name)
          /* Itt az x a modell elemünk.
           * Ebben az esetben a StudentList objectum.
           * x.Name nincs.
           * Itt a ciklusváltozó nevét kérjük el és nézzük meg hogy létezik e Name argumentuma.
           * De lehetett volna: @Html.DisplayNameFor(x => x.Students.First().Name) is.
           */
      </td>
      <td>
          @student.Name
      </td>
  </tr>
}
```

---

### 1.2.3. `View` kiválasztása

A `Controller` osztályban a `return View()`-nak lehet átadni paramétert.

Ha meg akarjuk mondani direktbe hogy melyik `View`-t kérem:

(alapértelmezetten megkeresi nekünk, ha ugyan azzal a névvel hoztuk létre mint a függvényt)

```cs
return View("Contact");
```

```cs
return View("~/Views/Home/Contact.cshtml");
//Ez akár kinyerhető adatbázisból is
```

De olyat is lehet, hogy:

```cs
return View("StudentDetails", student);
//Ez a StudentDetails-ban van
```

```cs
return View("~/Views/Home/StudentDetails.cshtml", student);
//Ez a StudentDetails-ban van
```

---

**`ViewBag`-ből nem lehet átadni kliensről controller-be adatot**

```cs
@using (Html.BeginForm()) // Ha nem adunk meg semmit akkor POST
@using (Html.BeginForm("Edit", "Student", FormMethod.Post))
```

`FormCollection` tartalmaz minden olyan elemet amit tartalmaz a képernyő.

## 1.3. WEB API

Követendő:

- 1 `Controller` egy **entitással** kéne hogy foglalkozzon.
- Visszatérési értéke az API-nak inkább legyen **JSON**.

---

Controllerek azok lehetnek amik az `ApiController`-ből származnak.

https://localhost:44311/api/Values

`Values` -> `ValuesController`

- GET
  - https://localhost:44311/api/Values

      ```cs
      // GET api/values
      public IEnumerable<string> Get()
      {
          return new string[] { "value1", "value2" };
      }
      ```

  - https://localhost:44311/api/Values/5
  - https://localhost:44311/api/Values?id=221

      ```cs
      // GET api/values/5
      public string Get(int id)
      {
          return "value";
      }
      ```

- POST
  - https://localhost:44311/api/Values
    - Postman
      - body: raw
      - header: content-type: application/json

    ```cs
    // POST api/values
    public void Post([FromBody] string value)
    {
    }
    ```

- PUT
  - *szeretnénk frissíteni valamit*
  - https://localhost:44311/api/Values
  - https://localhost:44311/api/Values/88
  - https://localhost:44311/api/Values?id=76
  - Postman
    - body: raw
    - header: content-type: application/json

    ```cs
    // PUT api/values/5
    public void Put(int id, [FromBody] string value)
    {
    }
    ```

- DELETE
  - https://localhost:44311/api/Values
  - https://localhost:44311/api/Values/88
  - https://localhost:44311/api/Values?id=76
  - Postman
    - body: raw
    - header: content-type: application/json

    ```cs
    // DELETE api/values/5
    public void Delete(int id)
    {
    }
    ```

---

### 1.3.1.1. Areas

Szét lehet vágni az alkalmazást területekre

---

Hozzunk létre a `Models` mappába egy `Bike` osztályt.

```cs
public class Bike
{
    public long ID { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public byte NumberOfWheels { get; set; }
    public bool IsFrontSuspension { get; set; }
    public bool IsRearSuspension { get; set; }
    public double FrameSize { get; set; }
    public double WheelSize { get; set; }
    public double WheelWidth { get; set; }
    public string Description { get; set; }
}
```

Hozzunk létre a `Controllers` mappába egy `BikeController`-t.

```cs
public class BikeController : ApiController
{
    //lista
    public List<Bike> Get()
    {
        //db-ből query/load
        //bike model lista készít
        //return

        return new List<Bike>()
        {
            new Bike(){ID = 1, Color = "Red", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, WheelWidth = 2.55, Description="good"},
            new Bike(){ID = 2, Color = "d", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, WheelWidth = 2.55, Description="good"},
            new Bike(){ID = 3, Color = "dsa", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, WheelWidth = 2.55, Description="good"},
            new Bike(){ID = 4, Color = "Blue", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, WheelWidth = 2.55, Description="good"}
        };
    }

    //https://localhost:44311/api/Bike?wheelSize=26
    //https://localhost:44311/api/Bike?wheelSize=26&tyreWidth=4
    //Ha csak az egyik paraméternek adok értéket, akkor a sima Get()-re menne,
    //de mivel adunk default értéket, így nem.
    public List<Bike> Get(double wheelSize, double tyreWidth = 2.55)
    {
        //db-ből query/load
        //bike model lista készít
        //return

        var list = new List<Bike>()
        {
            new Bike(){ID = 1, Color = "Red", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, TyreWidth = 2.55, Description="good"},
            new Bike(){ID = 2, Color = "d", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, TyreWidth = 2.55, Description="good"},
            new Bike(){ID = 3, Color = "dsa", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, TyreWidth = 2.55, Description="good"},
            new Bike(){ID = 4, Color = "Blue", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, TyreWidth = 2.55, Description="good"}
        };

        return list.Where(x => x.WheelSize == wheelSize && x.TyreWidth == tyreWidth).ToList();
    }

    public Bike Get(long id)
    {
        return new Bike() { ID = id, Color = "Red", FrameSize = 21, IsFrontSuspension = true, IsRearSuspension = true, NumberOfWheels = 2, Type = "MTB", WheelSize = 26, WheelWidth = 2.55, Description = "good" };
    }

    //https://localhost:44311/api/Bike?priority=55
    //Postman-ban a POST-bál a body-ba kell egy Bike-nak a JSON-ját betenni és itt megkapja
    public Bike Post([FromBody]Bike bike, [FromUri] int priority = 0)
    {
        //letárolni, id-t kapunk, frissül az objektum
        bike.ID = 34423423; //ha nem adunk meg a JSON-ban ID-t, akkor itt tudunk neki adni

        return bike;
    }

    // Ne használjunk bool viszatérést, jobb a statuscode
    public HttpStatusCode Put(long id, [FromBody] Bike bike)
    {
        //lekéred, frissíted, úgy küldöd tovább
        //bike.ID = id;
        //return bike;

        var successfulUpdate = true;
        if (successfulUpdate)
        {
            return HttpStatusCode.OK;
        }
        else
        {
            return HttpStatusCode.NotModified;
        }
    }
}
```

Postman: POST - https://localhost:44311/api/Bike

Ha `XML`-t akarunk visszakapni, akkor `Headers` -> új kulcs: `Accept` - `application/xml`

*JSON-nál kevesebb adatot kell átküldeni*.

---

### 1.3.1.2. Verziózás

Több projekt használja az API-nkat, de mi frissítünk, ők meg még nem, akkor nálunk nem lesz jó.

*Ez még nem verziózás:*

```cs
public class TestV1Controller : ApiController
{
    public virtual string Get()
    {
        return "1-es verzió megvalósítása";
    }


    public string Get(int id)
    {
        return $"id: {id}";
    }
}

public class TestV2Controller : TestV1Controller
{
    public override string Get()
    {
        return "2-es verzió megvalósítása";
    }
}
```

Az igazi verziózáshoz kell egy NuGet Package. *(Tools -> NuGet Package Manager -> Console)*

`Install-Package Microsoft.AspNet.WebApi.Versioning -Version 2.3.0`

`WebApiConfig.cs`:

```cs
public static void Register(HttpConfiguration config)
{
    // Web API configuration and services
    config.AddApiVersioning(o =>
    {
        o.ReportApiVersions = true;
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new Microsoft.Web.Http.ApiVersion(1, 0); //1.0
        o.ApiVersionReader = new HeaderApiVersionReader("api-version");
        o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
    });
```

majd hozzá kell írni:

```cs
[ApiVersion("1.0")]
[Route("api/Test")]
[ControllerName("Test")]
public class TestV1Controller : ApiController
```

```cs
[ApiVersion("2.0")]
[Route("api/Test")]
[ControllerName("Test")]
public class TestV2Controller : TestV1Controller
```

Hívásnál csak: `https://localhost:44311/api/Test`, és a `header`-be: `api-version` - `1.0` vagy `2.0`

Ha le akarjuk járatni az egyik verziót: `[ApiVersion("1.0", Deprecated = true)]`

Így is fog menni, de a `header`-ben benne van `api-deprecated-versions: 1.0`

## 1.4. Complett project

### 1.4.1. Logika

A `Presentation` layer csak a `BusinessLogic`-ot ismerheti.

A `BusinessLogic`layer csak a `DataAccess` layert ismeri.

## 1.5. Model

A model tartomány specifikus adatot reprezentál a business logic layerben.

Az adatokat publikus propertykkel jellemzi, a business locig-ot pedig metódusokkal.
