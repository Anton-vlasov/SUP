
//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SUP.Repository
{

using System;
    using System.Collections.Generic;
    
public partial class Employee
{

    public Employee()
    {

        this.ProjectWorks = new HashSet<ProjectWork>();

        this.Tasks = new HashSet<Task>();

        this.Tasks1 = new HashSet<Task>();

        this.Vacations = new HashSet<Vacation>();

    }


    public System.Guid Id { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string LastName { get; set; }

    public System.Guid Type { get; set; }

    public bool IsRemoved { get; set; }



    public virtual EmployeeType EmployeeType { get; set; }

    public virtual ICollection<ProjectWork> ProjectWorks { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }

    public virtual ICollection<Task> Tasks1 { get; set; }

    public virtual ICollection<Vacation> Vacations { get; set; }

}

}
