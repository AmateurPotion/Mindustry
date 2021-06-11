// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamAuth
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
  public class SteamAuth : Object
  {
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamAuth()
    {
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamAuth$AuthSessionResponse;>;")]
    [Modifiers]
    [Serializable]
    public sealed class AuthSessionResponse : Enum
    {
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EOK;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EUserNotConnectedToSteam;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003ENoLicenseOrExpired;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EVACBanned;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003ELoggedInElseWhere;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EVACCheckTimedOut;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EAuthTicketCanceled;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EAuthTicketInvalidAlreadyUsed;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EAuthTicketInvalid;
      [Modifiers]
      internal static SteamAuth.AuthSessionResponse __\u003C\u003EPublisherIssuedBan;
      [Modifiers]
      private static SteamAuth.AuthSessionResponse[] values;
      [Modifiers]
      private static SteamAuth.AuthSessionResponse[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(23)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private AuthSessionResponse([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(23)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.AuthSessionResponse[] values() => (SteamAuth.AuthSessionResponse[]) SteamAuth.AuthSessionResponse.\u0024VALUES.Clone();

      [LineNumberTable(23)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.AuthSessionResponse valueOf(string name) => (SteamAuth.AuthSessionResponse) Enum.valueOf((Class) ClassLiteral<SteamAuth.AuthSessionResponse>.Value, name);

      [LineNumberTable(38)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamAuth.AuthSessionResponse byOrdinal([In] int obj0) => SteamAuth.AuthSessionResponse.values[obj0];

      [LineNumberTable(new byte[] {159, 136, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 241, 54, 255, 62, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static AuthSessionResponse()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamAuth$AuthSessionResponse"))
          return;
        SteamAuth.AuthSessionResponse.__\u003C\u003EOK = new SteamAuth.AuthSessionResponse(nameof (OK), 0);
        SteamAuth.AuthSessionResponse.__\u003C\u003EUserNotConnectedToSteam = new SteamAuth.AuthSessionResponse(nameof (UserNotConnectedToSteam), 1);
        SteamAuth.AuthSessionResponse.__\u003C\u003ENoLicenseOrExpired = new SteamAuth.AuthSessionResponse(nameof (NoLicenseOrExpired), 2);
        SteamAuth.AuthSessionResponse.__\u003C\u003EVACBanned = new SteamAuth.AuthSessionResponse(nameof (VACBanned), 3);
        SteamAuth.AuthSessionResponse.__\u003C\u003ELoggedInElseWhere = new SteamAuth.AuthSessionResponse(nameof (LoggedInElseWhere), 4);
        SteamAuth.AuthSessionResponse.__\u003C\u003EVACCheckTimedOut = new SteamAuth.AuthSessionResponse(nameof (VACCheckTimedOut), 5);
        SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketCanceled = new SteamAuth.AuthSessionResponse(nameof (AuthTicketCanceled), 6);
        SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalidAlreadyUsed = new SteamAuth.AuthSessionResponse(nameof (AuthTicketInvalidAlreadyUsed), 7);
        SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalid = new SteamAuth.AuthSessionResponse(nameof (AuthTicketInvalid), 8);
        SteamAuth.AuthSessionResponse.__\u003C\u003EPublisherIssuedBan = new SteamAuth.AuthSessionResponse(nameof (PublisherIssuedBan), 9);
        SteamAuth.AuthSessionResponse.\u0024VALUES = new SteamAuth.AuthSessionResponse[10]
        {
          SteamAuth.AuthSessionResponse.__\u003C\u003EOK,
          SteamAuth.AuthSessionResponse.__\u003C\u003EUserNotConnectedToSteam,
          SteamAuth.AuthSessionResponse.__\u003C\u003ENoLicenseOrExpired,
          SteamAuth.AuthSessionResponse.__\u003C\u003EVACBanned,
          SteamAuth.AuthSessionResponse.__\u003C\u003ELoggedInElseWhere,
          SteamAuth.AuthSessionResponse.__\u003C\u003EVACCheckTimedOut,
          SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketCanceled,
          SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalidAlreadyUsed,
          SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalid,
          SteamAuth.AuthSessionResponse.__\u003C\u003EPublisherIssuedBan
        };
        SteamAuth.AuthSessionResponse.values = SteamAuth.AuthSessionResponse.values();
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse OK
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EOK;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse UserNotConnectedToSteam
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EUserNotConnectedToSteam;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse NoLicenseOrExpired
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003ENoLicenseOrExpired;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse VACBanned
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EVACBanned;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse LoggedInElseWhere
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003ELoggedInElseWhere;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse VACCheckTimedOut
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EVACCheckTimedOut;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse AuthTicketCanceled
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketCanceled;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse AuthTicketInvalidAlreadyUsed
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalidAlreadyUsed;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse AuthTicketInvalid
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EAuthTicketInvalid;
      }

      [Modifiers]
      public static SteamAuth.AuthSessionResponse PublisherIssuedBan
      {
        [HideFromJava] get => SteamAuth.AuthSessionResponse.__\u003C\u003EPublisherIssuedBan;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        OK,
        UserNotConnectedToSteam,
        NoLicenseOrExpired,
        VACBanned,
        LoggedInElseWhere,
        VACCheckTimedOut,
        AuthTicketCanceled,
        AuthTicketInvalidAlreadyUsed,
        AuthTicketInvalid,
        PublisherIssuedBan,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamAuth$BeginAuthSessionResult;>;")]
    [Modifiers]
    [Serializable]
    public sealed class BeginAuthSessionResult : Enum
    {
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EOK;
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EInvalidTicket;
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EDuplicateRequest;
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EInvalidVersion;
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EGameMismatch;
      [Modifiers]
      internal static SteamAuth.BeginAuthSessionResult __\u003C\u003EExpiredTicket;
      [Modifiers]
      private static SteamAuth.BeginAuthSessionResult[] values;
      [Modifiers]
      private static SteamAuth.BeginAuthSessionResult[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BeginAuthSessionResult([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.BeginAuthSessionResult[] values() => (SteamAuth.BeginAuthSessionResult[]) SteamAuth.BeginAuthSessionResult.\u0024VALUES.Clone();

      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.BeginAuthSessionResult valueOf(string name) => (SteamAuth.BeginAuthSessionResult) Enum.valueOf((Class) ClassLiteral<SteamAuth.BeginAuthSessionResult>.Value, name);

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamAuth.BeginAuthSessionResult byOrdinal([In] int obj0) => SteamAuth.BeginAuthSessionResult.values[obj0];

      [LineNumberTable(new byte[] {159, 140, 109, 112, 112, 112, 112, 112, 240, 58, 255, 28, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static BeginAuthSessionResult()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamAuth$BeginAuthSessionResult"))
          return;
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EOK = new SteamAuth.BeginAuthSessionResult(nameof (OK), 0);
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidTicket = new SteamAuth.BeginAuthSessionResult(nameof (InvalidTicket), 1);
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EDuplicateRequest = new SteamAuth.BeginAuthSessionResult(nameof (DuplicateRequest), 2);
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidVersion = new SteamAuth.BeginAuthSessionResult(nameof (InvalidVersion), 3);
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EGameMismatch = new SteamAuth.BeginAuthSessionResult(nameof (GameMismatch), 4);
        SteamAuth.BeginAuthSessionResult.__\u003C\u003EExpiredTicket = new SteamAuth.BeginAuthSessionResult(nameof (ExpiredTicket), 5);
        SteamAuth.BeginAuthSessionResult.\u0024VALUES = new SteamAuth.BeginAuthSessionResult[6]
        {
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EOK,
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidTicket,
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EDuplicateRequest,
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidVersion,
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EGameMismatch,
          SteamAuth.BeginAuthSessionResult.__\u003C\u003EExpiredTicket
        };
        SteamAuth.BeginAuthSessionResult.values = SteamAuth.BeginAuthSessionResult.values();
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult OK
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EOK;
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult InvalidTicket
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidTicket;
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult DuplicateRequest
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EDuplicateRequest;
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult InvalidVersion
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EInvalidVersion;
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult GameMismatch
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EGameMismatch;
      }

      [Modifiers]
      public static SteamAuth.BeginAuthSessionResult ExpiredTicket
      {
        [HideFromJava] get => SteamAuth.BeginAuthSessionResult.__\u003C\u003EExpiredTicket;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        OK,
        InvalidTicket,
        DuplicateRequest,
        InvalidVersion,
        GameMismatch,
        ExpiredTicket,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamAuth$UserHasLicenseForAppResult;>;")]
    [Modifiers]
    [Serializable]
    public sealed class UserHasLicenseForAppResult : Enum
    {
      [Modifiers]
      internal static SteamAuth.UserHasLicenseForAppResult __\u003C\u003EHasLicense;
      [Modifiers]
      internal static SteamAuth.UserHasLicenseForAppResult __\u003C\u003EDoesNotHaveLicense;
      [Modifiers]
      internal static SteamAuth.UserHasLicenseForAppResult __\u003C\u003ENoAuth;
      [Modifiers]
      private static SteamAuth.UserHasLicenseForAppResult[] values;
      [Modifiers]
      private static SteamAuth.UserHasLicenseForAppResult[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UserHasLicenseForAppResult([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.UserHasLicenseForAppResult[] values() => (SteamAuth.UserHasLicenseForAppResult[]) SteamAuth.UserHasLicenseForAppResult.\u0024VALUES.Clone();

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamAuth.UserHasLicenseForAppResult valueOf(string name) => (SteamAuth.UserHasLicenseForAppResult) Enum.valueOf((Class) ClassLiteral<SteamAuth.UserHasLicenseForAppResult>.Value, name);

      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamAuth.UserHasLicenseForAppResult byOrdinal([In] int obj0) => SteamAuth.UserHasLicenseForAppResult.values[obj0];

      [LineNumberTable(new byte[] {159, 132, 173, 112, 112, 240, 61, 255, 4, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static UserHasLicenseForAppResult()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamAuth$UserHasLicenseForAppResult"))
          return;
        SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EHasLicense = new SteamAuth.UserHasLicenseForAppResult(nameof (HasLicense), 0);
        SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EDoesNotHaveLicense = new SteamAuth.UserHasLicenseForAppResult(nameof (DoesNotHaveLicense), 1);
        SteamAuth.UserHasLicenseForAppResult.__\u003C\u003ENoAuth = new SteamAuth.UserHasLicenseForAppResult(nameof (NoAuth), 2);
        SteamAuth.UserHasLicenseForAppResult.\u0024VALUES = new SteamAuth.UserHasLicenseForAppResult[3]
        {
          SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EHasLicense,
          SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EDoesNotHaveLicense,
          SteamAuth.UserHasLicenseForAppResult.__\u003C\u003ENoAuth
        };
        SteamAuth.UserHasLicenseForAppResult.values = SteamAuth.UserHasLicenseForAppResult.values();
      }

      [Modifiers]
      public static SteamAuth.UserHasLicenseForAppResult HasLicense
      {
        [HideFromJava] get => SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EHasLicense;
      }

      [Modifiers]
      public static SteamAuth.UserHasLicenseForAppResult DoesNotHaveLicense
      {
        [HideFromJava] get => SteamAuth.UserHasLicenseForAppResult.__\u003C\u003EDoesNotHaveLicense;
      }

      [Modifiers]
      public static SteamAuth.UserHasLicenseForAppResult NoAuth
      {
        [HideFromJava] get => SteamAuth.UserHasLicenseForAppResult.__\u003C\u003ENoAuth;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        HasLicense,
        DoesNotHaveLicense,
        NoAuth,
      }
    }
  }
}
