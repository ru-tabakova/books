using Books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Helpers
{
    public class IsbnAttribute : ValidationAttribute
    {
        public IsbnAttribute()
        {
        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;

            if (book != null && IsValidISBN((string)value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"Wrong ISBN: {value}");
        }

        private bool IsValidISBN(string isbn)
        {

            // length must be 10 
            int n = isbn.Length;
            if (n != 10)
                return false;

            // Computing weighted sum of  
            // first 9 digits 
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';

                if (0 > digit || 9 < digit)
                    return false;

                sum += (digit * (10 - i));
            }

            // Checking last digit. 
            char last = isbn[9];
            if (last != 'X' && (last < '0'
                             || last > '9'))
                return false;

            // If last digit is 'X', add 10  
            // to sum, else add its value. 
            sum += ((last == 'X') ? 10 :
                              (last - '0'));

            // Return true if weighted sum  
            // of digits is divisible by 11. 
            return (sum % 11 == 0);
        }
    }
}
