using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAssignment.FeatureSteps
{
    public class RegistrationCredential
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    }

    public class GmailCredential
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreatFormSummary
    {
        public string Summary { get; set; }
    }
}
