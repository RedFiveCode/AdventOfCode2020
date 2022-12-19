using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class PassportRecord
    {
        public PassportRecord()
        {
            BirthYear = null;
            IssueYear = null;
            ExpirationYear = null;
            Height = null;
            HairColour = null;
            EyeColour = null;
            PassportId = null;
            CountryId = null;
        }

        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColour { get; set; }
        public string EyeColour { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid()
        {
            return IsNotNullAndNotEmpty(BirthYear) &&
                IsNotNullAndNotEmpty(IssueYear) &&
                IsNotNullAndNotEmpty(ExpirationYear) &&
                IsNotNullAndNotEmpty(Height) &&
                IsNotNullAndNotEmpty(HairColour) &&
                IsNotNullAndNotEmpty(EyeColour) &&
                IsNotNullAndNotEmpty(PassportId);
            // cid is optional
        }

        private bool IsNotNullAndNotEmpty(string value)
        {
            return value != null && value.Length > 0;
        }
    }
 }
