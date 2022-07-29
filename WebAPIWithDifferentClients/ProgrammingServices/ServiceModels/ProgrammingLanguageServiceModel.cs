namespace ProgrammingServices.ServiceModels
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProgrammingModels.Models;

    public class ProgrammingLanguageServiceModel
    {    
        public int Id { get; set; }
        public string Name { get; set; }
     
        public string Description { get; set; }

        public ICollection<Tutorial> Tutorials { get; set; }
    }
}
