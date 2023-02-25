using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string AuthorizationDenied = "Authorization Failed.";

        public static string UserRegistered = "User registered successfully.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password is incorrect.";
        public static string SuccessfulLogin = "Login successful.";
        public static string UserAlreadyExists = "User already exists.";
        public static string AccessTokenCreated = "Access token created successfully.";
        public static string RemainingPassword { get; set; } = "Remaining attempts: ";
        public static string ExceededAttempt { get; set; } = "You have exceeded the attempt limit";
        public static string RetryAfterMinute { get; set; } = "The amount of time to wait before retrying to login (Minute): ";     
    }
}
