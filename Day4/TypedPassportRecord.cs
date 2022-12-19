using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    enum HeightUnits { Unknown, Centimetres, Inches }
    enum EyeColour { Unknown, Amber, Blue, Brown, Grey, Green, Hazel, Other }

    class TypedPassportRecord
    {
        public TypedPassportRecord()
        {
            BirthYear = -1;
            IssueYear = -1;
            ExpirationYear = -1;

            Height = -1;
            HeightUnits = HeightUnits.Unknown;

            HairColour = null;
            EyeColour = EyeColour.Unknown;
            
            PassportId = null;
            CountryId = null;
        }

        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public int Height { get; set; }
        public HeightUnits HeightUnits { get; set; }
        public string HairColour { get; set; }
        public EyeColour EyeColour { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid()
        {
            return IsValidBirthYear() &&
                   IsValidIssueYear() &&
                   IsValidExpirationYear() &&
                   IsValidHeight() &&
                   IsValidEyeColour() &&
                   IsValidHairColour() &&
                   IsValidPassportId();
            // cid is optional
        }

        public bool AreFieldsPresent()
        {
            return BirthYear != -1 &&
                IssueYear != -1 &&
                ExpirationYear != -1 &&
                Height != -1 &&
                HeightUnits != HeightUnits.Unknown &&
                HairColour != null &&
                EyeColour != EyeColour.Unknown &&
                PassportId != null;
        }

        public override string ToString()
        {
            var units = new Dictionary<HeightUnits, string>()
            {
                { HeightUnits.Centimetres, "cm" },
                { HeightUnits.Inches, "in" },
                { HeightUnits.Unknown, "" }
            };

            var eyeColors = new Dictionary<EyeColour, string>()
            {
                { EyeColour.Amber, "amb" },
                { EyeColour.Blue, "blu" },
                { EyeColour.Brown, "brn" },
                { EyeColour.Grey, "gry" },
                { EyeColour.Green, "grn" },
                { EyeColour.Hazel, "hzl" },
                { EyeColour.Other, "oth" },
                { EyeColour.Unknown, "" },
            };

            var builder = new StringBuilder();
            builder.Append($"BirthYear={BirthYear}, ");
            builder.Append($"IssueYear={IssueYear}, ");
            builder.Append($"ExpirationYear={ExpirationYear}, ");
            builder.Append($"Height={Height}{units[HeightUnits]}, ");
            builder.Append($"HairColour={HairColour}, ");
            builder.Append($"EyeColour={eyeColors[EyeColour]}, ");
            builder.Append($"PassportId={PassportId}");
            builder.AppendLine();

            return builder.ToString();
        }

        private bool IsValidBirthYear()
        {
            return BirthYear >= 1920 && BirthYear <= 2002;
        }

        private bool IsValidIssueYear()
        {
            return IssueYear >= 2010 && IssueYear <= 2020;
        }

        private bool IsValidExpirationYear()
        {
            return ExpirationYear >= 2020 && ExpirationYear <= 2030;
        }

        private bool IsValidHeight()
        {
            if (HeightUnits == HeightUnits.Centimetres)
            {
                return Height >= 150 && Height <= 193;
            }

            if (HeightUnits == HeightUnits.Inches)
            {
                return Height >= 59 && Height <= 76;
            }

            return false;
        }

        private bool IsValidEyeColour()
        {
            return EyeColour != EyeColour.Unknown;
        }

        private bool IsValidHairColour()
        {
            if (String.IsNullOrEmpty(HairColour))
            {
                return false;
            }

            var regex = new Regex("#[0-9a-f]{6}");

            return regex.IsMatch(HairColour);
        }

        private bool IsValidPassportId()
        {
            if (String.IsNullOrEmpty(PassportId))
            {
                return false;
            }

            if (PassportId.Length != 9)
            {
                return false;
            }

            var regex = new Regex(@"\d{9}");

            return regex.IsMatch(PassportId);
        }
    }
}
