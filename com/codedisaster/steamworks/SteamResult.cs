// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamResult
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamResult;>;")]
  [Modifiers]
  [Serializable]
  public sealed class SteamResult : Enum
  {
    [Modifiers]
    internal static SteamResult __\u003C\u003EOK;
    [Modifiers]
    internal static SteamResult __\u003C\u003EFail;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENoConnection;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidPassword;
    [Modifiers]
    internal static SteamResult __\u003C\u003ELoggedInElsewhere;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidProtocolVer;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidParam;
    [Modifiers]
    internal static SteamResult __\u003C\u003EFileNotFound;
    [Modifiers]
    internal static SteamResult __\u003C\u003EBusy;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidState;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidName;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidEmail;
    [Modifiers]
    internal static SteamResult __\u003C\u003EDuplicateName;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccessDenied;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETimeout;
    [Modifiers]
    internal static SteamResult __\u003C\u003EBanned;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountNotFound;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidSteamID;
    [Modifiers]
    internal static SteamResult __\u003C\u003EServiceUnavailable;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENotLoggedOn;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPending;
    [Modifiers]
    internal static SteamResult __\u003C\u003EEncryptionFailure;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInsufficientPrivilege;
    [Modifiers]
    internal static SteamResult __\u003C\u003ELimitExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERevoked;
    [Modifiers]
    internal static SteamResult __\u003C\u003EExpired;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAlreadyRedeemed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EDuplicateRequest;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAlreadyOwned;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIPNotFound;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPersistFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003ELockingFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003ELogonSessionReplaced;
    [Modifiers]
    internal static SteamResult __\u003C\u003EConnectFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EHandshakeFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIOFailure;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERemoteDisconnect;
    [Modifiers]
    internal static SteamResult __\u003C\u003EShoppingCartNotFound;
    [Modifiers]
    internal static SteamResult __\u003C\u003EBlocked;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIgnored;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENoMatch;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountDisabled;
    [Modifiers]
    internal static SteamResult __\u003C\u003EServiceReadOnly;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountNotFeatured;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAdministratorOK;
    [Modifiers]
    internal static SteamResult __\u003C\u003EContentVersion;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETryAnotherCM;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPasswordRequiredToKickSession;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAlreadyLoggedInElsewhere;
    [Modifiers]
    internal static SteamResult __\u003C\u003ESuspended;
    [Modifiers]
    internal static SteamResult __\u003C\u003ECancelled;
    [Modifiers]
    internal static SteamResult __\u003C\u003EDataCorruption;
    [Modifiers]
    internal static SteamResult __\u003C\u003EDiskFull;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERemoteCallFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPasswordUnset;
    [Modifiers]
    internal static SteamResult __\u003C\u003EExternalAccountUnlinked;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPSNTicketInvalid;
    [Modifiers]
    internal static SteamResult __\u003C\u003EExternalAccountAlreadyLinked;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERemoteFileConflict;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIllegalPassword;
    [Modifiers]
    internal static SteamResult __\u003C\u003ESameAsPreviousValue;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLogonDenied;
    [Modifiers]
    internal static SteamResult __\u003C\u003ECannotUseOldPassword;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidLoginAuthCode;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLogonDeniedNoMail;
    [Modifiers]
    internal static SteamResult __\u003C\u003EHardwareNotCapableOfIPT;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIPTInitError;
    [Modifiers]
    internal static SteamResult __\u003C\u003EParentalControlRestricted;
    [Modifiers]
    internal static SteamResult __\u003C\u003EFacebookQueryError;
    [Modifiers]
    internal static SteamResult __\u003C\u003EExpiredLoginAuthCode;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIPLoginRestrictionFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLockedDown;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLogonDeniedVerifiedEmailRequired;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENoMatchingURL;
    [Modifiers]
    internal static SteamResult __\u003C\u003EBadResponse;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERequirePasswordReEntry;
    [Modifiers]
    internal static SteamResult __\u003C\u003EValueOutOfRange;
    [Modifiers]
    internal static SteamResult __\u003C\u003EUnexpectedError;
    [Modifiers]
    internal static SteamResult __\u003C\u003EDisabled;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidCEGSubmission;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERestrictedDevice;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERegionLocked;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERateLimitExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLoginDeniedNeedTwoFactor;
    [Modifiers]
    internal static SteamResult __\u003C\u003EItemDeleted;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLoginDeniedThrottle;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETwoFactorCodeMismatch;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETwoFactorActivationCodeMismatch;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountAssociatedToMultiplePartners;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENotModified;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENoMobileDevice;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETimeNotSynced;
    [Modifiers]
    internal static SteamResult __\u003C\u003ESmsCodeFailed;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountLimitExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountActivityLimitExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003EPhoneActivityLimitExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003ERefundToWallet;
    [Modifiers]
    internal static SteamResult __\u003C\u003EEmailSendFailure;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENotSettled;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENeedCaptcha;
    [Modifiers]
    internal static SteamResult __\u003C\u003EGSLTDenied;
    [Modifiers]
    internal static SteamResult __\u003C\u003EGSOwnerDenied;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInvalidItemType;
    [Modifiers]
    internal static SteamResult __\u003C\u003EIPBanned;
    [Modifiers]
    internal static SteamResult __\u003C\u003EGLSTExpired;
    [Modifiers]
    internal static SteamResult __\u003C\u003EInsufficientFunds;
    [Modifiers]
    internal static SteamResult __\u003C\u003ETooManyPending;
    [Modifiers]
    internal static SteamResult __\u003C\u003ENoSiteLicensesFound;
    [Modifiers]
    internal static SteamResult __\u003C\u003EWGNetworkSendExceeded;
    [Modifiers]
    internal static SteamResult __\u003C\u003EAccountNotFriends;
    [Modifiers]
    internal static SteamResult __\u003C\u003ELimitedUserAccount;
    [Modifiers]
    internal static SteamResult __\u003C\u003EUnknownErrorCode_NotImplementedByAPI;
    [Modifiers]
    private int code;
    [Modifiers]
    private static SteamResult[] valuesLookupTable;
    [Modifiers]
    private static SteamResult[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {84, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamResult byValue(int resultCode) => resultCode < SteamResult.valuesLookupTable.Length ? SteamResult.valuesLookupTable[resultCode] : SteamResult.__\u003C\u003EUnknownErrorCode_NotImplementedByAPI;

    [Signature("(I)V")]
    [LineNumberTable(new byte[] {79, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SteamResult([In] string obj0, [In] int obj1, [In] int obj2)
      : base(obj0, obj1)
    {
      SteamResult steamResult = this;
      this.code = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamResult[] values() => (SteamResult[]) SteamResult.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamResult valueOf(string name) => (SteamResult) Enum.valueOf((Class) ClassLiteral<SteamResult>.Value, name);

    [LineNumberTable(new byte[] {159, 140, 77, 113, 113, 145, 113, 113, 113, 113, 114, 114, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 243, 69, 242, 159, 135, 255, 163, 148, 160, 139, 102, 130, 115, 46, 200, 141, 115, 47, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamResult()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamResult"))
        return;
      SteamResult.__\u003C\u003EOK = new SteamResult(nameof (OK), 0, 1);
      SteamResult.__\u003C\u003EFail = new SteamResult(nameof (Fail), 1, 2);
      SteamResult.__\u003C\u003ENoConnection = new SteamResult(nameof (NoConnection), 2, 3);
      SteamResult.__\u003C\u003EInvalidPassword = new SteamResult(nameof (InvalidPassword), 3, 5);
      SteamResult.__\u003C\u003ELoggedInElsewhere = new SteamResult(nameof (LoggedInElsewhere), 4, 6);
      SteamResult.__\u003C\u003EInvalidProtocolVer = new SteamResult(nameof (InvalidProtocolVer), 5, 7);
      SteamResult.__\u003C\u003EInvalidParam = new SteamResult(nameof (InvalidParam), 6, 8);
      SteamResult.__\u003C\u003EFileNotFound = new SteamResult(nameof (FileNotFound), 7, 9);
      SteamResult.__\u003C\u003EBusy = new SteamResult(nameof (Busy), 8, 10);
      SteamResult.__\u003C\u003EInvalidState = new SteamResult(nameof (InvalidState), 9, 11);
      SteamResult.__\u003C\u003EInvalidName = new SteamResult(nameof (InvalidName), 10, 12);
      SteamResult.__\u003C\u003EInvalidEmail = new SteamResult(nameof (InvalidEmail), 11, 13);
      SteamResult.__\u003C\u003EDuplicateName = new SteamResult(nameof (DuplicateName), 12, 14);
      SteamResult.__\u003C\u003EAccessDenied = new SteamResult(nameof (AccessDenied), 13, 15);
      SteamResult.__\u003C\u003ETimeout = new SteamResult(nameof (Timeout), 14, 16);
      SteamResult.__\u003C\u003EBanned = new SteamResult(nameof (Banned), 15, 17);
      SteamResult.__\u003C\u003EAccountNotFound = new SteamResult(nameof (AccountNotFound), 16, 18);
      SteamResult.__\u003C\u003EInvalidSteamID = new SteamResult(nameof (InvalidSteamID), 17, 19);
      SteamResult.__\u003C\u003EServiceUnavailable = new SteamResult(nameof (ServiceUnavailable), 18, 20);
      SteamResult.__\u003C\u003ENotLoggedOn = new SteamResult(nameof (NotLoggedOn), 19, 21);
      SteamResult.__\u003C\u003EPending = new SteamResult(nameof (Pending), 20, 22);
      SteamResult.__\u003C\u003EEncryptionFailure = new SteamResult(nameof (EncryptionFailure), 21, 23);
      SteamResult.__\u003C\u003EInsufficientPrivilege = new SteamResult(nameof (InsufficientPrivilege), 22, 24);
      SteamResult.__\u003C\u003ELimitExceeded = new SteamResult(nameof (LimitExceeded), 23, 25);
      SteamResult.__\u003C\u003ERevoked = new SteamResult(nameof (Revoked), 24, 26);
      SteamResult.__\u003C\u003EExpired = new SteamResult(nameof (Expired), 25, 27);
      SteamResult.__\u003C\u003EAlreadyRedeemed = new SteamResult(nameof (AlreadyRedeemed), 26, 28);
      SteamResult.__\u003C\u003EDuplicateRequest = new SteamResult(nameof (DuplicateRequest), 27, 29);
      SteamResult.__\u003C\u003EAlreadyOwned = new SteamResult(nameof (AlreadyOwned), 28, 30);
      SteamResult.__\u003C\u003EIPNotFound = new SteamResult(nameof (IPNotFound), 29, 31);
      SteamResult.__\u003C\u003EPersistFailed = new SteamResult(nameof (PersistFailed), 30, 32);
      SteamResult.__\u003C\u003ELockingFailed = new SteamResult(nameof (LockingFailed), 31, 33);
      SteamResult.__\u003C\u003ELogonSessionReplaced = new SteamResult(nameof (LogonSessionReplaced), 32, 34);
      SteamResult.__\u003C\u003EConnectFailed = new SteamResult(nameof (ConnectFailed), 33, 35);
      SteamResult.__\u003C\u003EHandshakeFailed = new SteamResult(nameof (HandshakeFailed), 34, 36);
      SteamResult.__\u003C\u003EIOFailure = new SteamResult(nameof (IOFailure), 35, 37);
      SteamResult.__\u003C\u003ERemoteDisconnect = new SteamResult(nameof (RemoteDisconnect), 36, 38);
      SteamResult.__\u003C\u003EShoppingCartNotFound = new SteamResult(nameof (ShoppingCartNotFound), 37, 39);
      SteamResult.__\u003C\u003EBlocked = new SteamResult(nameof (Blocked), 38, 40);
      SteamResult.__\u003C\u003EIgnored = new SteamResult(nameof (Ignored), 39, 41);
      SteamResult.__\u003C\u003ENoMatch = new SteamResult(nameof (NoMatch), 40, 42);
      SteamResult.__\u003C\u003EAccountDisabled = new SteamResult(nameof (AccountDisabled), 41, 43);
      SteamResult.__\u003C\u003EServiceReadOnly = new SteamResult(nameof (ServiceReadOnly), 42, 44);
      SteamResult.__\u003C\u003EAccountNotFeatured = new SteamResult(nameof (AccountNotFeatured), 43, 45);
      SteamResult.__\u003C\u003EAdministratorOK = new SteamResult(nameof (AdministratorOK), 44, 46);
      SteamResult.__\u003C\u003EContentVersion = new SteamResult(nameof (ContentVersion), 45, 47);
      SteamResult.__\u003C\u003ETryAnotherCM = new SteamResult(nameof (TryAnotherCM), 46, 48);
      SteamResult.__\u003C\u003EPasswordRequiredToKickSession = new SteamResult(nameof (PasswordRequiredToKickSession), 47, 49);
      SteamResult.__\u003C\u003EAlreadyLoggedInElsewhere = new SteamResult(nameof (AlreadyLoggedInElsewhere), 48, 50);
      SteamResult.__\u003C\u003ESuspended = new SteamResult(nameof (Suspended), 49, 51);
      SteamResult.__\u003C\u003ECancelled = new SteamResult(nameof (Cancelled), 50, 52);
      SteamResult.__\u003C\u003EDataCorruption = new SteamResult(nameof (DataCorruption), 51, 53);
      SteamResult.__\u003C\u003EDiskFull = new SteamResult(nameof (DiskFull), 52, 54);
      SteamResult.__\u003C\u003ERemoteCallFailed = new SteamResult(nameof (RemoteCallFailed), 53, 55);
      SteamResult.__\u003C\u003EPasswordUnset = new SteamResult(nameof (PasswordUnset), 54, 56);
      SteamResult.__\u003C\u003EExternalAccountUnlinked = new SteamResult(nameof (ExternalAccountUnlinked), 55, 57);
      SteamResult.__\u003C\u003EPSNTicketInvalid = new SteamResult(nameof (PSNTicketInvalid), 56, 58);
      SteamResult.__\u003C\u003EExternalAccountAlreadyLinked = new SteamResult(nameof (ExternalAccountAlreadyLinked), 57, 59);
      SteamResult.__\u003C\u003ERemoteFileConflict = new SteamResult(nameof (RemoteFileConflict), 58, 60);
      SteamResult.__\u003C\u003EIllegalPassword = new SteamResult(nameof (IllegalPassword), 59, 61);
      SteamResult.__\u003C\u003ESameAsPreviousValue = new SteamResult(nameof (SameAsPreviousValue), 60, 62);
      SteamResult.__\u003C\u003EAccountLogonDenied = new SteamResult(nameof (AccountLogonDenied), 61, 63);
      SteamResult.__\u003C\u003ECannotUseOldPassword = new SteamResult(nameof (CannotUseOldPassword), 62, 64);
      SteamResult.__\u003C\u003EInvalidLoginAuthCode = new SteamResult(nameof (InvalidLoginAuthCode), 63, 65);
      SteamResult.__\u003C\u003EAccountLogonDeniedNoMail = new SteamResult(nameof (AccountLogonDeniedNoMail), 64, 66);
      SteamResult.__\u003C\u003EHardwareNotCapableOfIPT = new SteamResult(nameof (HardwareNotCapableOfIPT), 65, 67);
      SteamResult.__\u003C\u003EIPTInitError = new SteamResult(nameof (IPTInitError), 66, 68);
      SteamResult.__\u003C\u003EParentalControlRestricted = new SteamResult(nameof (ParentalControlRestricted), 67, 69);
      SteamResult.__\u003C\u003EFacebookQueryError = new SteamResult(nameof (FacebookQueryError), 68, 70);
      SteamResult.__\u003C\u003EExpiredLoginAuthCode = new SteamResult(nameof (ExpiredLoginAuthCode), 69, 71);
      SteamResult.__\u003C\u003EIPLoginRestrictionFailed = new SteamResult(nameof (IPLoginRestrictionFailed), 70, 72);
      SteamResult.__\u003C\u003EAccountLockedDown = new SteamResult(nameof (AccountLockedDown), 71, 73);
      SteamResult.__\u003C\u003EAccountLogonDeniedVerifiedEmailRequired = new SteamResult(nameof (AccountLogonDeniedVerifiedEmailRequired), 72, 74);
      SteamResult.__\u003C\u003ENoMatchingURL = new SteamResult(nameof (NoMatchingURL), 73, 75);
      SteamResult.__\u003C\u003EBadResponse = new SteamResult(nameof (BadResponse), 74, 76);
      SteamResult.__\u003C\u003ERequirePasswordReEntry = new SteamResult(nameof (RequirePasswordReEntry), 75, 77);
      SteamResult.__\u003C\u003EValueOutOfRange = new SteamResult(nameof (ValueOutOfRange), 76, 78);
      SteamResult.__\u003C\u003EUnexpectedError = new SteamResult(nameof (UnexpectedError), 77, 79);
      SteamResult.__\u003C\u003EDisabled = new SteamResult(nameof (Disabled), 78, 80);
      SteamResult.__\u003C\u003EInvalidCEGSubmission = new SteamResult(nameof (InvalidCEGSubmission), 79, 81);
      SteamResult.__\u003C\u003ERestrictedDevice = new SteamResult(nameof (RestrictedDevice), 80, 82);
      SteamResult.__\u003C\u003ERegionLocked = new SteamResult(nameof (RegionLocked), 81, 83);
      SteamResult.__\u003C\u003ERateLimitExceeded = new SteamResult(nameof (RateLimitExceeded), 82, 84);
      SteamResult.__\u003C\u003EAccountLoginDeniedNeedTwoFactor = new SteamResult(nameof (AccountLoginDeniedNeedTwoFactor), 83, 85);
      SteamResult.__\u003C\u003EItemDeleted = new SteamResult(nameof (ItemDeleted), 84, 86);
      SteamResult.__\u003C\u003EAccountLoginDeniedThrottle = new SteamResult(nameof (AccountLoginDeniedThrottle), 85, 87);
      SteamResult.__\u003C\u003ETwoFactorCodeMismatch = new SteamResult(nameof (TwoFactorCodeMismatch), 86, 88);
      SteamResult.__\u003C\u003ETwoFactorActivationCodeMismatch = new SteamResult(nameof (TwoFactorActivationCodeMismatch), 87, 89);
      SteamResult.__\u003C\u003EAccountAssociatedToMultiplePartners = new SteamResult(nameof (AccountAssociatedToMultiplePartners), 88, 90);
      SteamResult.__\u003C\u003ENotModified = new SteamResult(nameof (NotModified), 89, 91);
      SteamResult.__\u003C\u003ENoMobileDevice = new SteamResult(nameof (NoMobileDevice), 90, 92);
      SteamResult.__\u003C\u003ETimeNotSynced = new SteamResult(nameof (TimeNotSynced), 91, 93);
      SteamResult.__\u003C\u003ESmsCodeFailed = new SteamResult(nameof (SmsCodeFailed), 92, 94);
      SteamResult.__\u003C\u003EAccountLimitExceeded = new SteamResult(nameof (AccountLimitExceeded), 93, 95);
      SteamResult.__\u003C\u003EAccountActivityLimitExceeded = new SteamResult(nameof (AccountActivityLimitExceeded), 94, 96);
      SteamResult.__\u003C\u003EPhoneActivityLimitExceeded = new SteamResult(nameof (PhoneActivityLimitExceeded), 95, 97);
      SteamResult.__\u003C\u003ERefundToWallet = new SteamResult(nameof (RefundToWallet), 96, 98);
      SteamResult.__\u003C\u003EEmailSendFailure = new SteamResult(nameof (EmailSendFailure), 97, 99);
      SteamResult.__\u003C\u003ENotSettled = new SteamResult(nameof (NotSettled), 98, 100);
      SteamResult.__\u003C\u003ENeedCaptcha = new SteamResult(nameof (NeedCaptcha), 99, 101);
      SteamResult.__\u003C\u003EGSLTDenied = new SteamResult(nameof (GSLTDenied), 100, 102);
      SteamResult.__\u003C\u003EGSOwnerDenied = new SteamResult(nameof (GSOwnerDenied), 101, 103);
      SteamResult.__\u003C\u003EInvalidItemType = new SteamResult(nameof (InvalidItemType), 102, 104);
      SteamResult.__\u003C\u003EIPBanned = new SteamResult(nameof (IPBanned), 103, 105);
      SteamResult.__\u003C\u003EGLSTExpired = new SteamResult(nameof (GLSTExpired), 104, 106);
      SteamResult.__\u003C\u003EInsufficientFunds = new SteamResult(nameof (InsufficientFunds), 105, 107);
      SteamResult.__\u003C\u003ETooManyPending = new SteamResult(nameof (TooManyPending), 106, 108);
      SteamResult.__\u003C\u003ENoSiteLicensesFound = new SteamResult(nameof (NoSiteLicensesFound), 107, 109);
      SteamResult.__\u003C\u003EWGNetworkSendExceeded = new SteamResult(nameof (WGNetworkSendExceeded), 108, 110);
      SteamResult.__\u003C\u003EAccountNotFriends = new SteamResult(nameof (AccountNotFriends), 109, 111);
      SteamResult.__\u003C\u003ELimitedUserAccount = new SteamResult(nameof (LimitedUserAccount), 110, 112);
      SteamResult.__\u003C\u003EUnknownErrorCode_NotImplementedByAPI = new SteamResult(nameof (UnknownErrorCode_NotImplementedByAPI), 111, 0);
      SteamResult.\u0024VALUES = new SteamResult[112]
      {
        SteamResult.__\u003C\u003EOK,
        SteamResult.__\u003C\u003EFail,
        SteamResult.__\u003C\u003ENoConnection,
        SteamResult.__\u003C\u003EInvalidPassword,
        SteamResult.__\u003C\u003ELoggedInElsewhere,
        SteamResult.__\u003C\u003EInvalidProtocolVer,
        SteamResult.__\u003C\u003EInvalidParam,
        SteamResult.__\u003C\u003EFileNotFound,
        SteamResult.__\u003C\u003EBusy,
        SteamResult.__\u003C\u003EInvalidState,
        SteamResult.__\u003C\u003EInvalidName,
        SteamResult.__\u003C\u003EInvalidEmail,
        SteamResult.__\u003C\u003EDuplicateName,
        SteamResult.__\u003C\u003EAccessDenied,
        SteamResult.__\u003C\u003ETimeout,
        SteamResult.__\u003C\u003EBanned,
        SteamResult.__\u003C\u003EAccountNotFound,
        SteamResult.__\u003C\u003EInvalidSteamID,
        SteamResult.__\u003C\u003EServiceUnavailable,
        SteamResult.__\u003C\u003ENotLoggedOn,
        SteamResult.__\u003C\u003EPending,
        SteamResult.__\u003C\u003EEncryptionFailure,
        SteamResult.__\u003C\u003EInsufficientPrivilege,
        SteamResult.__\u003C\u003ELimitExceeded,
        SteamResult.__\u003C\u003ERevoked,
        SteamResult.__\u003C\u003EExpired,
        SteamResult.__\u003C\u003EAlreadyRedeemed,
        SteamResult.__\u003C\u003EDuplicateRequest,
        SteamResult.__\u003C\u003EAlreadyOwned,
        SteamResult.__\u003C\u003EIPNotFound,
        SteamResult.__\u003C\u003EPersistFailed,
        SteamResult.__\u003C\u003ELockingFailed,
        SteamResult.__\u003C\u003ELogonSessionReplaced,
        SteamResult.__\u003C\u003EConnectFailed,
        SteamResult.__\u003C\u003EHandshakeFailed,
        SteamResult.__\u003C\u003EIOFailure,
        SteamResult.__\u003C\u003ERemoteDisconnect,
        SteamResult.__\u003C\u003EShoppingCartNotFound,
        SteamResult.__\u003C\u003EBlocked,
        SteamResult.__\u003C\u003EIgnored,
        SteamResult.__\u003C\u003ENoMatch,
        SteamResult.__\u003C\u003EAccountDisabled,
        SteamResult.__\u003C\u003EServiceReadOnly,
        SteamResult.__\u003C\u003EAccountNotFeatured,
        SteamResult.__\u003C\u003EAdministratorOK,
        SteamResult.__\u003C\u003EContentVersion,
        SteamResult.__\u003C\u003ETryAnotherCM,
        SteamResult.__\u003C\u003EPasswordRequiredToKickSession,
        SteamResult.__\u003C\u003EAlreadyLoggedInElsewhere,
        SteamResult.__\u003C\u003ESuspended,
        SteamResult.__\u003C\u003ECancelled,
        SteamResult.__\u003C\u003EDataCorruption,
        SteamResult.__\u003C\u003EDiskFull,
        SteamResult.__\u003C\u003ERemoteCallFailed,
        SteamResult.__\u003C\u003EPasswordUnset,
        SteamResult.__\u003C\u003EExternalAccountUnlinked,
        SteamResult.__\u003C\u003EPSNTicketInvalid,
        SteamResult.__\u003C\u003EExternalAccountAlreadyLinked,
        SteamResult.__\u003C\u003ERemoteFileConflict,
        SteamResult.__\u003C\u003EIllegalPassword,
        SteamResult.__\u003C\u003ESameAsPreviousValue,
        SteamResult.__\u003C\u003EAccountLogonDenied,
        SteamResult.__\u003C\u003ECannotUseOldPassword,
        SteamResult.__\u003C\u003EInvalidLoginAuthCode,
        SteamResult.__\u003C\u003EAccountLogonDeniedNoMail,
        SteamResult.__\u003C\u003EHardwareNotCapableOfIPT,
        SteamResult.__\u003C\u003EIPTInitError,
        SteamResult.__\u003C\u003EParentalControlRestricted,
        SteamResult.__\u003C\u003EFacebookQueryError,
        SteamResult.__\u003C\u003EExpiredLoginAuthCode,
        SteamResult.__\u003C\u003EIPLoginRestrictionFailed,
        SteamResult.__\u003C\u003EAccountLockedDown,
        SteamResult.__\u003C\u003EAccountLogonDeniedVerifiedEmailRequired,
        SteamResult.__\u003C\u003ENoMatchingURL,
        SteamResult.__\u003C\u003EBadResponse,
        SteamResult.__\u003C\u003ERequirePasswordReEntry,
        SteamResult.__\u003C\u003EValueOutOfRange,
        SteamResult.__\u003C\u003EUnexpectedError,
        SteamResult.__\u003C\u003EDisabled,
        SteamResult.__\u003C\u003EInvalidCEGSubmission,
        SteamResult.__\u003C\u003ERestrictedDevice,
        SteamResult.__\u003C\u003ERegionLocked,
        SteamResult.__\u003C\u003ERateLimitExceeded,
        SteamResult.__\u003C\u003EAccountLoginDeniedNeedTwoFactor,
        SteamResult.__\u003C\u003EItemDeleted,
        SteamResult.__\u003C\u003EAccountLoginDeniedThrottle,
        SteamResult.__\u003C\u003ETwoFactorCodeMismatch,
        SteamResult.__\u003C\u003ETwoFactorActivationCodeMismatch,
        SteamResult.__\u003C\u003EAccountAssociatedToMultiplePartners,
        SteamResult.__\u003C\u003ENotModified,
        SteamResult.__\u003C\u003ENoMobileDevice,
        SteamResult.__\u003C\u003ETimeNotSynced,
        SteamResult.__\u003C\u003ESmsCodeFailed,
        SteamResult.__\u003C\u003EAccountLimitExceeded,
        SteamResult.__\u003C\u003EAccountActivityLimitExceeded,
        SteamResult.__\u003C\u003EPhoneActivityLimitExceeded,
        SteamResult.__\u003C\u003ERefundToWallet,
        SteamResult.__\u003C\u003EEmailSendFailure,
        SteamResult.__\u003C\u003ENotSettled,
        SteamResult.__\u003C\u003ENeedCaptcha,
        SteamResult.__\u003C\u003EGSLTDenied,
        SteamResult.__\u003C\u003EGSOwnerDenied,
        SteamResult.__\u003C\u003EInvalidItemType,
        SteamResult.__\u003C\u003EIPBanned,
        SteamResult.__\u003C\u003EGLSTExpired,
        SteamResult.__\u003C\u003EInsufficientFunds,
        SteamResult.__\u003C\u003ETooManyPending,
        SteamResult.__\u003C\u003ENoSiteLicensesFound,
        SteamResult.__\u003C\u003EWGNetworkSendExceeded,
        SteamResult.__\u003C\u003EAccountNotFriends,
        SteamResult.__\u003C\u003ELimitedUserAccount,
        SteamResult.__\u003C\u003EUnknownErrorCode_NotImplementedByAPI
      };
      SteamResult[] steamResultArray1 = SteamResult.values();
      int num = 0;
      SteamResult[] steamResultArray2 = steamResultArray1;
      int length1 = steamResultArray2.Length;
      for (int index = 0; index < length1; ++index)
      {
        SteamResult steamResult = steamResultArray2[index];
        num = Math.max(num, steamResult.code);
      }
      SteamResult.valuesLookupTable = new SteamResult[num + 1];
      SteamResult[] steamResultArray3 = steamResultArray1;
      int length2 = steamResultArray3.Length;
      for (int index = 0; index < length2; ++index)
      {
        SteamResult steamResult = steamResultArray3[index];
        SteamResult.valuesLookupTable[steamResult.code] = steamResult;
      }
    }

    [Modifiers]
    public static SteamResult OK
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EOK;
    }

    [Modifiers]
    public static SteamResult Fail
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EFail;
    }

    [Modifiers]
    public static SteamResult NoConnection
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENoConnection;
    }

    [Modifiers]
    public static SteamResult InvalidPassword
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidPassword;
    }

    [Modifiers]
    public static SteamResult LoggedInElsewhere
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ELoggedInElsewhere;
    }

    [Modifiers]
    public static SteamResult InvalidProtocolVer
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidProtocolVer;
    }

    [Modifiers]
    public static SteamResult InvalidParam
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidParam;
    }

    [Modifiers]
    public static SteamResult FileNotFound
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EFileNotFound;
    }

    [Modifiers]
    public static SteamResult Busy
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EBusy;
    }

    [Modifiers]
    public static SteamResult InvalidState
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidState;
    }

    [Modifiers]
    public static SteamResult InvalidName
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidName;
    }

    [Modifiers]
    public static SteamResult InvalidEmail
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidEmail;
    }

    [Modifiers]
    public static SteamResult DuplicateName
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EDuplicateName;
    }

    [Modifiers]
    public static SteamResult AccessDenied
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccessDenied;
    }

    [Modifiers]
    public static SteamResult Timeout
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETimeout;
    }

    [Modifiers]
    public static SteamResult Banned
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EBanned;
    }

    [Modifiers]
    public static SteamResult AccountNotFound
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountNotFound;
    }

    [Modifiers]
    public static SteamResult InvalidSteamID
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidSteamID;
    }

    [Modifiers]
    public static SteamResult ServiceUnavailable
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EServiceUnavailable;
    }

    [Modifiers]
    public static SteamResult NotLoggedOn
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENotLoggedOn;
    }

    [Modifiers]
    public static SteamResult Pending
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPending;
    }

    [Modifiers]
    public static SteamResult EncryptionFailure
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EEncryptionFailure;
    }

    [Modifiers]
    public static SteamResult InsufficientPrivilege
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInsufficientPrivilege;
    }

    [Modifiers]
    public static SteamResult LimitExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ELimitExceeded;
    }

    [Modifiers]
    public static SteamResult Revoked
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERevoked;
    }

    [Modifiers]
    public static SteamResult Expired
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EExpired;
    }

    [Modifiers]
    public static SteamResult AlreadyRedeemed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAlreadyRedeemed;
    }

    [Modifiers]
    public static SteamResult DuplicateRequest
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EDuplicateRequest;
    }

    [Modifiers]
    public static SteamResult AlreadyOwned
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAlreadyOwned;
    }

    [Modifiers]
    public static SteamResult IPNotFound
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIPNotFound;
    }

    [Modifiers]
    public static SteamResult PersistFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPersistFailed;
    }

    [Modifiers]
    public static SteamResult LockingFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ELockingFailed;
    }

    [Modifiers]
    public static SteamResult LogonSessionReplaced
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ELogonSessionReplaced;
    }

    [Modifiers]
    public static SteamResult ConnectFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EConnectFailed;
    }

    [Modifiers]
    public static SteamResult HandshakeFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EHandshakeFailed;
    }

    [Modifiers]
    public static SteamResult IOFailure
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIOFailure;
    }

    [Modifiers]
    public static SteamResult RemoteDisconnect
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERemoteDisconnect;
    }

    [Modifiers]
    public static SteamResult ShoppingCartNotFound
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EShoppingCartNotFound;
    }

    [Modifiers]
    public static SteamResult Blocked
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EBlocked;
    }

    [Modifiers]
    public static SteamResult Ignored
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIgnored;
    }

    [Modifiers]
    public static SteamResult NoMatch
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENoMatch;
    }

    [Modifiers]
    public static SteamResult AccountDisabled
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountDisabled;
    }

    [Modifiers]
    public static SteamResult ServiceReadOnly
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EServiceReadOnly;
    }

    [Modifiers]
    public static SteamResult AccountNotFeatured
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountNotFeatured;
    }

    [Modifiers]
    public static SteamResult AdministratorOK
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAdministratorOK;
    }

    [Modifiers]
    public static SteamResult ContentVersion
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EContentVersion;
    }

    [Modifiers]
    public static SteamResult TryAnotherCM
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETryAnotherCM;
    }

    [Modifiers]
    public static SteamResult PasswordRequiredToKickSession
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPasswordRequiredToKickSession;
    }

    [Modifiers]
    public static SteamResult AlreadyLoggedInElsewhere
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAlreadyLoggedInElsewhere;
    }

    [Modifiers]
    public static SteamResult Suspended
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ESuspended;
    }

    [Modifiers]
    public static SteamResult Cancelled
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ECancelled;
    }

    [Modifiers]
    public static SteamResult DataCorruption
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EDataCorruption;
    }

    [Modifiers]
    public static SteamResult DiskFull
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EDiskFull;
    }

    [Modifiers]
    public static SteamResult RemoteCallFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERemoteCallFailed;
    }

    [Modifiers]
    public static SteamResult PasswordUnset
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPasswordUnset;
    }

    [Modifiers]
    public static SteamResult ExternalAccountUnlinked
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EExternalAccountUnlinked;
    }

    [Modifiers]
    public static SteamResult PSNTicketInvalid
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPSNTicketInvalid;
    }

    [Modifiers]
    public static SteamResult ExternalAccountAlreadyLinked
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EExternalAccountAlreadyLinked;
    }

    [Modifiers]
    public static SteamResult RemoteFileConflict
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERemoteFileConflict;
    }

    [Modifiers]
    public static SteamResult IllegalPassword
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIllegalPassword;
    }

    [Modifiers]
    public static SteamResult SameAsPreviousValue
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ESameAsPreviousValue;
    }

    [Modifiers]
    public static SteamResult AccountLogonDenied
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLogonDenied;
    }

    [Modifiers]
    public static SteamResult CannotUseOldPassword
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ECannotUseOldPassword;
    }

    [Modifiers]
    public static SteamResult InvalidLoginAuthCode
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidLoginAuthCode;
    }

    [Modifiers]
    public static SteamResult AccountLogonDeniedNoMail
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLogonDeniedNoMail;
    }

    [Modifiers]
    public static SteamResult HardwareNotCapableOfIPT
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EHardwareNotCapableOfIPT;
    }

    [Modifiers]
    public static SteamResult IPTInitError
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIPTInitError;
    }

    [Modifiers]
    public static SteamResult ParentalControlRestricted
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EParentalControlRestricted;
    }

    [Modifiers]
    public static SteamResult FacebookQueryError
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EFacebookQueryError;
    }

    [Modifiers]
    public static SteamResult ExpiredLoginAuthCode
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EExpiredLoginAuthCode;
    }

    [Modifiers]
    public static SteamResult IPLoginRestrictionFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIPLoginRestrictionFailed;
    }

    [Modifiers]
    public static SteamResult AccountLockedDown
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLockedDown;
    }

    [Modifiers]
    public static SteamResult AccountLogonDeniedVerifiedEmailRequired
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLogonDeniedVerifiedEmailRequired;
    }

    [Modifiers]
    public static SteamResult NoMatchingURL
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENoMatchingURL;
    }

    [Modifiers]
    public static SteamResult BadResponse
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EBadResponse;
    }

    [Modifiers]
    public static SteamResult RequirePasswordReEntry
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERequirePasswordReEntry;
    }

    [Modifiers]
    public static SteamResult ValueOutOfRange
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EValueOutOfRange;
    }

    [Modifiers]
    public static SteamResult UnexpectedError
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EUnexpectedError;
    }

    [Modifiers]
    public static SteamResult Disabled
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EDisabled;
    }

    [Modifiers]
    public static SteamResult InvalidCEGSubmission
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidCEGSubmission;
    }

    [Modifiers]
    public static SteamResult RestrictedDevice
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERestrictedDevice;
    }

    [Modifiers]
    public static SteamResult RegionLocked
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERegionLocked;
    }

    [Modifiers]
    public static SteamResult RateLimitExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERateLimitExceeded;
    }

    [Modifiers]
    public static SteamResult AccountLoginDeniedNeedTwoFactor
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLoginDeniedNeedTwoFactor;
    }

    [Modifiers]
    public static SteamResult ItemDeleted
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EItemDeleted;
    }

    [Modifiers]
    public static SteamResult AccountLoginDeniedThrottle
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLoginDeniedThrottle;
    }

    [Modifiers]
    public static SteamResult TwoFactorCodeMismatch
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETwoFactorCodeMismatch;
    }

    [Modifiers]
    public static SteamResult TwoFactorActivationCodeMismatch
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETwoFactorActivationCodeMismatch;
    }

    [Modifiers]
    public static SteamResult AccountAssociatedToMultiplePartners
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountAssociatedToMultiplePartners;
    }

    [Modifiers]
    public static SteamResult NotModified
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENotModified;
    }

    [Modifiers]
    public static SteamResult NoMobileDevice
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENoMobileDevice;
    }

    [Modifiers]
    public static SteamResult TimeNotSynced
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETimeNotSynced;
    }

    [Modifiers]
    public static SteamResult SmsCodeFailed
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ESmsCodeFailed;
    }

    [Modifiers]
    public static SteamResult AccountLimitExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountLimitExceeded;
    }

    [Modifiers]
    public static SteamResult AccountActivityLimitExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountActivityLimitExceeded;
    }

    [Modifiers]
    public static SteamResult PhoneActivityLimitExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EPhoneActivityLimitExceeded;
    }

    [Modifiers]
    public static SteamResult RefundToWallet
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ERefundToWallet;
    }

    [Modifiers]
    public static SteamResult EmailSendFailure
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EEmailSendFailure;
    }

    [Modifiers]
    public static SteamResult NotSettled
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENotSettled;
    }

    [Modifiers]
    public static SteamResult NeedCaptcha
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENeedCaptcha;
    }

    [Modifiers]
    public static SteamResult GSLTDenied
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EGSLTDenied;
    }

    [Modifiers]
    public static SteamResult GSOwnerDenied
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EGSOwnerDenied;
    }

    [Modifiers]
    public static SteamResult InvalidItemType
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInvalidItemType;
    }

    [Modifiers]
    public static SteamResult IPBanned
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EIPBanned;
    }

    [Modifiers]
    public static SteamResult GLSTExpired
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EGLSTExpired;
    }

    [Modifiers]
    public static SteamResult InsufficientFunds
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EInsufficientFunds;
    }

    [Modifiers]
    public static SteamResult TooManyPending
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ETooManyPending;
    }

    [Modifiers]
    public static SteamResult NoSiteLicensesFound
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ENoSiteLicensesFound;
    }

    [Modifiers]
    public static SteamResult WGNetworkSendExceeded
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EWGNetworkSendExceeded;
    }

    [Modifiers]
    public static SteamResult AccountNotFriends
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EAccountNotFriends;
    }

    [Modifiers]
    public static SteamResult LimitedUserAccount
    {
      [HideFromJava] get => SteamResult.__\u003C\u003ELimitedUserAccount;
    }

    [Modifiers]
    public static SteamResult UnknownErrorCode_NotImplementedByAPI
    {
      [HideFromJava] get => SteamResult.__\u003C\u003EUnknownErrorCode_NotImplementedByAPI;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      OK,
      Fail,
      NoConnection,
      InvalidPassword,
      LoggedInElsewhere,
      InvalidProtocolVer,
      InvalidParam,
      FileNotFound,
      Busy,
      InvalidState,
      InvalidName,
      InvalidEmail,
      DuplicateName,
      AccessDenied,
      Timeout,
      Banned,
      AccountNotFound,
      InvalidSteamID,
      ServiceUnavailable,
      NotLoggedOn,
      Pending,
      EncryptionFailure,
      InsufficientPrivilege,
      LimitExceeded,
      Revoked,
      Expired,
      AlreadyRedeemed,
      DuplicateRequest,
      AlreadyOwned,
      IPNotFound,
      PersistFailed,
      LockingFailed,
      LogonSessionReplaced,
      ConnectFailed,
      HandshakeFailed,
      IOFailure,
      RemoteDisconnect,
      ShoppingCartNotFound,
      Blocked,
      Ignored,
      NoMatch,
      AccountDisabled,
      ServiceReadOnly,
      AccountNotFeatured,
      AdministratorOK,
      ContentVersion,
      TryAnotherCM,
      PasswordRequiredToKickSession,
      AlreadyLoggedInElsewhere,
      Suspended,
      Cancelled,
      DataCorruption,
      DiskFull,
      RemoteCallFailed,
      PasswordUnset,
      ExternalAccountUnlinked,
      PSNTicketInvalid,
      ExternalAccountAlreadyLinked,
      RemoteFileConflict,
      IllegalPassword,
      SameAsPreviousValue,
      AccountLogonDenied,
      CannotUseOldPassword,
      InvalidLoginAuthCode,
      AccountLogonDeniedNoMail,
      HardwareNotCapableOfIPT,
      IPTInitError,
      ParentalControlRestricted,
      FacebookQueryError,
      ExpiredLoginAuthCode,
      IPLoginRestrictionFailed,
      AccountLockedDown,
      AccountLogonDeniedVerifiedEmailRequired,
      NoMatchingURL,
      BadResponse,
      RequirePasswordReEntry,
      ValueOutOfRange,
      UnexpectedError,
      Disabled,
      InvalidCEGSubmission,
      RestrictedDevice,
      RegionLocked,
      RateLimitExceeded,
      AccountLoginDeniedNeedTwoFactor,
      ItemDeleted,
      AccountLoginDeniedThrottle,
      TwoFactorCodeMismatch,
      TwoFactorActivationCodeMismatch,
      AccountAssociatedToMultiplePartners,
      NotModified,
      NoMobileDevice,
      TimeNotSynced,
      SmsCodeFailed,
      AccountLimitExceeded,
      AccountActivityLimitExceeded,
      PhoneActivityLimitExceeded,
      RefundToWallet,
      EmailSendFailure,
      NotSettled,
      NeedCaptcha,
      GSLTDenied,
      GSOwnerDenied,
      InvalidItemType,
      IPBanned,
      GLSTExpired,
      InsufficientFunds,
      TooManyPending,
      NoSiteLicensesFound,
      WGNetworkSendExceeded,
      AccountNotFriends,
      LimitedUserAccount,
      UnknownErrorCode_NotImplementedByAPI,
    }
  }
}
