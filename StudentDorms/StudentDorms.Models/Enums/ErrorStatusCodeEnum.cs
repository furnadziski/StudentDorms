namespace StudentDorms.Models.Enums
{
    /// <summary>
    /// Енумерација за статус кодовите кои се прикажуваат при грешка
    /// </summary>
    public enum ErrorStatusCodeEnum : int
    {
        /// <summary>
        /// Моделот не е валиден
        /// </summary>
        InvalidModel = 400,

        /// <summary>
        /// Неовластен пристап
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// НПАА грешка
        /// </summary>
        StudentDormsError = 409,

        /// <summary>
        /// Функцијата не е имплементирана
        /// </summary>
        NotImplemented = 410,

        /// <summary>
        /// Корисникот не е активен
        /// </summary>
        UserNotActive = 420,

        /// <summary>
        /// Корисникот не е регистриран
        /// </summary>
        UserNotRegistered = 430,

        /// <summary>
        /// Истечен токен
        /// </summary>
        TokenExpired = 450,

        /// <summary>
        /// Невалиден токен
        /// </summary>
        TokenNotValid = 460,

        /// <summary>
        /// Серверска грешка
        /// </summary>
        InternalServerError = 500
    }
}
