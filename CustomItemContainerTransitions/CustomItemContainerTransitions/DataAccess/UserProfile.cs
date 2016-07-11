namespace CustomItemContainerTransitions.DataAccess
{
    /// <summary>
    /// Model class for storing user data.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Mobile phone number.
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Profile image URL.
        /// </summary>
        public string ProfileImage { get; set; }
    }
}
