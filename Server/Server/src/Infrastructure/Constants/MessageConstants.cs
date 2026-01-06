namespace Server.Infrastructure.Constants;
internal static class MessageConstants
{
    #region User
    internal const string AdministratorsProfilesStatusCannotBeToggled = "Users.AdministratorsProfilesStatusCannotBeToggled";
    internal const string UserNotFound = "Users.UserNotFound";
    internal const string InvalidTenant = "Users.InvalidTenant";
    internal const string InvalidObjectId = "Users.InvalidObjectId";
    internal const string UsernameOrEmailNotValid = "Users.UsernameOrEmailNotValid.";
    internal const string ValidationErrorsOccurred = "Users.ValidationErrorsOccurred.";
    internal const string ConfirmRegistration = "Users.ConfirmRegistration";
    internal const string PhoneAlreadyUse = "Users.PhoneAlreadyUse";
    internal const string UpdateProfileFailed = "Users.UpdateProfileFailed";
    internal const string UserErrorDescription = "Users.ErrorDescription";
    internal const string ErrorAdminAccount = "Users.ErrorAdminAccount";
    internal const string DeleteProfileFailed = "Users.DeleteProfileFailed";
    #endregion


    #region Roles
    internal const string RoleNotFound = "Roles.NotFound";
    internal const string RoleDeleted = "Roles.Deleted";
    internal const string RegisterRoleFailed = "Roles.RegisterRoleFailed";
    internal const string RoleCreated = "Roles.Created";
    internal const string RoleNotAllowedToModify = "Roles.NotAllowedToModify";
    internal const string RoleUpdated = "Roles.Updated";
    internal const string NotAllowedToModifyPermissionsForThisRole = "Roles.NotAllowedToModifyPermissionsForThisRole";
    internal const string UpdatePermissionsFailed = "Roles.UpdatePermissionsFailed";
    internal const string UpdateRoleFailed = "Roles.UpdateRoleFailed";
    internal const string PermissionsUpdated = "Roles.PermissionsUpdated";
    internal const string NotAllowedToDeleteRole = "Roles.NotAllowedToDeleteRole";
    internal const string NotAllowedToDeleteRoleAsItIsBeingUsed = "Roles.NotAllowedToDeleteRoleAsItIsBeingUsed";
    #endregion


}



