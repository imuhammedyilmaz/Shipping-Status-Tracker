
using System;

namespace PackageExpress
{
    class Program
    {
        // Define shipping status enum
        enum ShippingStatus
        {
            Accepted,
            TooHeavy,
            TooBig,
            Error
        }
        
        static void Main(string[] args)
        {
            // Start with welcome message
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
            
            try
            {
                // Package properties
                float weight = 0, width = 0, height = 0, length = 0;
                
                // Get package weight
                Console.WriteLine("Please enter the package weight:");
                weight = float.Parse(Console.ReadLine());
                
                // Check weight limit first
                if (weight > 50)
                {
                    ProcessShippingStatus(ShippingStatus.TooHeavy);
                    return;
                }
                
                // Get package dimensions
                Console.WriteLine("Please enter the package width:");
                width = float.Parse(Console.ReadLine());
                
                Console.WriteLine("Please enter the package height:");
                height = float.Parse(Console.ReadLine());
                
                Console.WriteLine("Please enter the package length:");
                length = float.Parse(Console.ReadLine());
                
                // Check dimensions sum
                if (width + height + length > 50)
                {
                    ProcessShippingStatus(ShippingStatus.TooBig);
                    return;
                }
                
                // Calculate quote
                float quote = (width * height * length * weight) / 100;
                
                // Process successful shipping
                ProcessShippingStatus(ShippingStatus.Accepted, quote);
            }
            catch (Exception)
            {
                // Handle any input errors
                ProcessShippingStatus(ShippingStatus.Error);
            }
            finally
            {
                // Keep console window open
                Console.ReadLine();
            }
        }
        
        /// <summary>
        /// Process shipping status and display appropriate message
        /// </summary>
        /// <param name="status">Current shipping status</param>
        /// <param name="quote">Optional shipping quote</param>
        static void ProcessShippingStatus(ShippingStatus status, float quote = 0)
        {
            // Use switch to handle different statuses
            switch (status)
            {
                case ShippingStatus.Accepted:
                    // Show shipping quote
                    Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
                    Console.WriteLine("Thank you!");
                    break;
                    
                case ShippingStatus.TooHeavy:
                    // Show weight error
                    Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                    break;
                    
                case ShippingStatus.TooBig:
                    // Show size error
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    break;
                    
                case ShippingStatus.Error:
                    // Show generic error
                    Console.WriteLine("An error occurred processing your request. Please try again with valid numeric inputs.");
                    break;
                    
                default:
                    // Fallback for unexpected status
                    Console.WriteLine("Unknown shipping status. Please contact customer service.");
                    break;
            }
        }
    }
}