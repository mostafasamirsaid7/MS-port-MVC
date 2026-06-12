# Resource File Templates

Reference templates for creating new localization resource files. Copy and translate these to create proper `.resx` files.

## FormResource.resx (English Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Auth Form Labels -->
  <data name="Auth_Username" xml:space="preserve"><value>Username</value></data>
  <data name="Auth_Email" xml:space="preserve"><value>Email Address</value></data>
  <data name="Auth_Password" xml:space="preserve"><value>Password</value></data>
  <data name="Auth_ConfirmPassword" xml:space="preserve"><value>Confirm Password</value></data>
  <data name="Auth_RememberMe" xml:space="preserve"><value>Remember me</value></data>
  <data name="Auth_ForgotPassword" xml:space="preserve"><value>Forgot your password?</value></data>

  <!-- Blog Form Labels -->
  <data name="Blog_SearchPlaceholder" xml:space="preserve"><value>Search articles...</value></data>
  <data name="Blog_FilterByCategory" xml:space="preserve"><value>Filter by category</value></data>
  <data name="Blog_FilterByTag" xml:space="preserve"><value>Filter by tag</value></data>

  <!-- Comment Form Labels -->
  <data name="Comment_Name" xml:space="preserve"><value>Your Name</value></data>
  <data name="Comment_Email" xml:space="preserve"><value>Your Email</value></data>
  <data name="Comment_Website" xml:space="preserve"><value>Website (optional)</value></data>
  <data name="Comment_Content" xml:space="preserve"><value>Comment</value></data>
  <data name="Comment_PostComment" xml:space="preserve"><value>Post Comment</value></data>

  <!-- Newsletter Form Labels -->
  <data name="Newsletter_Email" xml:space="preserve"><value>Enter your email</value></data>
  <data name="Newsletter_Subscribe" xml:space="preserve"><value>Subscribe</value></data>

  <!-- Search Form -->
  <data name="Search_Placeholder" xml:space="preserve"><value>Search projects, articles...</value></data>
  <data name="Search_Button" xml:space="preserve"><value>Search</value></data>

</root>
```

---

## FormResource.ar.resx (Arabic Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Auth Form Labels -->
  <data name="Auth_Username" xml:space="preserve"><value>اسم المستخدم</value></data>
  <data name="Auth_Email" xml:space="preserve"><value>البريد الإلكتروني</value></data>
  <data name="Auth_Password" xml:space="preserve"><value>كلمة المرور</value></data>
  <data name="Auth_ConfirmPassword" xml:space="preserve"><value>تأكيد كلمة المرور</value></data>
  <data name="Auth_RememberMe" xml:space="preserve"><value>تذكرني</value></data>
  <data name="Auth_ForgotPassword" xml:space="preserve"><value>هل نسيت كلمة المرور؟</value></data>

  <!-- Blog Form Labels -->
  <data name="Blog_SearchPlaceholder" xml:space="preserve"><value>ابحث في المقالات...</value></data>
  <data name="Blog_FilterByCategory" xml:space="preserve"><value>التصفية حسب الفئة</value></data>
  <data name="Blog_FilterByTag" xml:space="preserve"><value>التصفية حسب العلامة</value></data>

  <!-- Comment Form Labels -->
  <data name="Comment_Name" xml:space="preserve"><value>اسمك</value></data>
  <data name="Comment_Email" xml:space="preserve"><value>بريدك الإلكتروني</value></data>
  <data name="Comment_Website" xml:space="preserve"><value>الموقع الإلكتروني (اختياري)</value></data>
  <data name="Comment_Content" xml:space="preserve"><value>التعليق</value></data>
  <data name="Comment_PostComment" xml:space="preserve"><value>إرسال التعليق</value></data>

  <!-- Newsletter Form Labels -->
  <data name="Newsletter_Email" xml:space="preserve"><value>أدخل بريدك الإلكتروني</value></data>
  <data name="Newsletter_Subscribe" xml:space="preserve"><value>اشترك</value></data>

  <!-- Search Form -->
  <data name="Search_Placeholder" xml:space="preserve"><value>ابحث عن المشاريع والمقالات...</value></data>
  <data name="Search_Button" xml:space="preserve"><value>بحث</value></data>

</root>
```

---

## AuthResource.resx (English Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Login Page -->
  <data name="Login_Title" xml:space="preserve"><value>Sign In</value></data>
  <data name="Login_Description" xml:space="preserve"><value>Welcome back! Please sign in to your account.</value></data>
  <data name="Login_EmailLabel" xml:space="preserve"><value>Email Address</value></data>
  <data name="Login_PasswordLabel" xml:space="preserve"><value>Password</value></data>
  <data name="Login_RememberMe" xml:space="preserve"><value>Remember me</value></data>
  <data name="Login_ForgotPassword" xml:space="preserve"><value>Forgot password?</value></data>
  <data name="Login_Button" xml:space="preserve"><value>Sign In</value></data>
  <data name="Login_NoAccount" xml:space="preserve"><value>Don't have an account?</value></data>
  <data name="Login_Register" xml:space="preserve"><value>Create one here</value></data>
  <data name="Login_InvalidCredentials" xml:space="preserve"><value>Invalid email or password.</value></data>

  <!-- Register Page -->
  <data name="Register_Title" xml:space="preserve"><value>Create Account</value></data>
  <data name="Register_Description" xml:space="preserve"><value>Join us today and start your journey.</value></data>
  <data name="Register_NameLabel" xml:space="preserve"><value>Full Name</value></data>
  <data name="Register_EmailLabel" xml:space="preserve"><value>Email Address</value></data>
  <data name="Register_PasswordLabel" xml:space="preserve"><value>Password</value></data>
  <data name="Register_ConfirmPasswordLabel" xml:space="preserve"><value>Confirm Password</value></data>
  <data name="Register_TermsLabel" xml:space="preserve"><value>I agree to the terms and conditions</value></data>
  <data name="Register_Button" xml:space="preserve"><value>Create Account</value></data>
  <data name="Register_AlreadyAccount" xml:space="preserve"><value>Already have an account?</value></data>
  <data name="Register_SignIn" xml:space="preserve"><value>Sign in here</value></data>
  <data name="Register_PasswordMismatch" xml:space="preserve"><value>Passwords do not match.</value></data>
  <data name="Register_EmailExists" xml:space="preserve"><value>Email already registered.</value></data>
  <data name="Register_Success" xml:space="preserve"><value>Account created successfully! Please check your email to verify.</value></data>

  <!-- Password Reset -->
  <data name="PasswordReset_Title" xml:space="preserve"><value>Reset Password</value></data>
  <data name="PasswordReset_Description" xml:space="preserve"><value>Enter your email to receive a password reset link.</value></data>
  <data name="PasswordReset_EmailLabel" xml:space="preserve"><value>Email Address</value></data>
  <data name="PasswordReset_SendLink" xml:space="preserve"><value>Send Reset Link</value></data>
  <data name="PasswordReset_CheckEmail" xml:space="preserve"><value>Check your email for a password reset link.</value></data>
  <data name="PasswordReset_InvalidEmail" xml:space="preserve"><value>Email not found.</value></data>

  <!-- Reset Password Confirmation -->
  <data name="ResetPasswordConfirm_Title" xml:space="preserve"><value>Create New Password</value></data>
  <data name="ResetPasswordConfirm_NewPasswordLabel" xml:space="preserve"><value>New Password</value></data>
  <data name="ResetPasswordConfirm_ConfirmLabel" xml:space="preserve"><value>Confirm Password</value></data>
  <data name="ResetPasswordConfirm_Button" xml:space="preserve"><value>Reset Password</value></data>
  <data name="ResetPasswordConfirm_Success" xml:space="preserve"><value>Password reset successfully!</value></data>
  <data name="ResetPasswordConfirm_InvalidToken" xml:space="preserve"><value>Invalid or expired reset token.</value></data>

  <!-- Profile Page -->
  <data name="Profile_Title" xml:space="preserve"><value>My Profile</value></data>
  <data name="Profile_PersonalInfo" xml:space="preserve"><value>Personal Information</value></data>
  <data name="Profile_EditProfile" xml:space="preserve"><value>Edit Profile</value></data>
  <data name="Profile_ChangePassword" xml:space="preserve"><value>Change Password</value></data>
  <data name="Profile_DeleteAccount" xml:space="preserve"><value>Delete Account</value></data>
  <data name="Profile_UpdateSuccess" xml:space="preserve"><value>Profile updated successfully!</value></data>

  <!-- Account Settings -->
  <data name="Settings_Title" xml:space="preserve"><value>Account Settings</value></data>
  <data name="Settings_Privacy" xml:space="preserve"><value>Privacy Settings</value></data>
  <data name="Settings_Notifications" xml:space="preserve"><value>Notification Preferences</value></data>
  <data name="Settings_SaveChanges" xml:space="preserve"><value>Save Changes</value></data>
  <data name="Settings_ChangesSaved" xml:space="preserve"><value>Changes saved successfully!</value></data>

</root>
```

---

## AuthResource.ar.resx (Arabic Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Login Page -->
  <data name="Login_Title" xml:space="preserve"><value>تسجيل الدخول</value></data>
  <data name="Login_Description" xml:space="preserve"><value>أهلاً بعودتك! يرجى تسجيل الدخول إلى حسابك.</value></data>
  <data name="Login_EmailLabel" xml:space="preserve"><value>البريد الإلكتروني</value></data>
  <data name="Login_PasswordLabel" xml:space="preserve"><value>كلمة المرور</value></data>
  <data name="Login_RememberMe" xml:space="preserve"><value>تذكرني</value></data>
  <data name="Login_ForgotPassword" xml:space="preserve"><value>هل نسيت كلمة المرور؟</value></data>
  <data name="Login_Button" xml:space="preserve"><value>تسجيل الدخول</value></data>
  <data name="Login_NoAccount" xml:space="preserve"><value>ليس لديك حساب؟</value></data>
  <data name="Login_Register" xml:space="preserve"><value>أنشئ واحداً هنا</value></data>
  <data name="Login_InvalidCredentials" xml:space="preserve"><value>بريد إلكتروني أو كلمة مرور غير صحيحة.</value></data>

  <!-- Register Page -->
  <data name="Register_Title" xml:space="preserve"><value>إنشاء حساب</value></data>
  <data name="Register_Description" xml:space="preserve"><value>انضم إلينا اليوم وابدأ رحلتك.</value></data>
  <data name="Register_NameLabel" xml:space="preserve"><value>الاسم الكامل</value></data>
  <data name="Register_EmailLabel" xml:space="preserve"><value>البريد الإلكتروني</value></data>
  <data name="Register_PasswordLabel" xml:space="preserve"><value>كلمة المرور</value></data>
  <data name="Register_ConfirmPasswordLabel" xml:space="preserve"><value>تأكيد كلمة المرور</value></data>
  <data name="Register_TermsLabel" xml:space="preserve"><value>أوافق على الشروط والأحكام</value></data>
  <data name="Register_Button" xml:space="preserve"><value>إنشاء حساب</value></data>
  <data name="Register_AlreadyAccount" xml:space="preserve"><value>هل لديك حساب بالفعل؟</value></data>
  <data name="Register_SignIn" xml:space="preserve"><value>سجل الدخول هنا</value></data>
  <data name="Register_PasswordMismatch" xml:space="preserve"><value>كلمات المرور غير متطابقة.</value></data>
  <data name="Register_EmailExists" xml:space="preserve"><value>البريد الإلكتروني مسجل بالفعل.</value></data>
  <data name="Register_Success" xml:space="preserve"><value>تم إنشاء الحساب بنجاح! يرجى التحقق من بريدك الإلكتروني.</value></data>

  <!-- Password Reset -->
  <data name="PasswordReset_Title" xml:space="preserve"><value>إعادة تعيين كلمة المرور</value></data>
  <data name="PasswordReset_Description" xml:space="preserve"><value>أدخل بريدك الإلكتروني لتلقي رابط إعادة تعيين كلمة المرور.</value></data>
  <data name="PasswordReset_EmailLabel" xml:space="preserve"><value>البريد الإلكتروني</value></data>
  <data name="PasswordReset_SendLink" xml:space="preserve"><value>إرسال رابط إعادة التعيين</value></data>
  <data name="PasswordReset_CheckEmail" xml:space="preserve"><value>تحقق من بريدك الإلكتروني للحصول على رابط إعادة تعيين.</value></data>
  <data name="PasswordReset_InvalidEmail" xml:space="preserve"><value>البريد الإلكتروني غير موجود.</value></data>

  <!-- Reset Password Confirmation -->
  <data name="ResetPasswordConfirm_Title" xml:space="preserve"><value>إنشاء كلمة مرور جديدة</value></data>
  <data name="ResetPasswordConfirm_NewPasswordLabel" xml:space="preserve"><value>كلمة مرور جديدة</value></data>
  <data name="ResetPasswordConfirm_ConfirmLabel" xml:space="preserve"><value>تأكيد كلمة المرور</value></data>
  <data name="ResetPasswordConfirm_Button" xml:space="preserve"><value>إعادة تعيين كلمة المرور</value></data>
  <data name="ResetPasswordConfirm_Success" xml:space="preserve"><value>تم إعادة تعيين كلمة المرور بنجاح!</value></data>
  <data name="ResetPasswordConfirm_InvalidToken" xml:space="preserve"><value>رمز إعادة تعيين غير صحيح أو منتهي الصلاحية.</value></data>

  <!-- Profile Page -->
  <data name="Profile_Title" xml:space="preserve"><value>ملفي الشخصي</value></data>
  <data name="Profile_PersonalInfo" xml:space="preserve"><value>المعلومات الشخصية</value></data>
  <data name="Profile_EditProfile" xml:space="preserve"><value>تعديل الملف الشخصي</value></data>
  <data name="Profile_ChangePassword" xml:space="preserve"><value>تغيير كلمة المرور</value></data>
  <data name="Profile_DeleteAccount" xml:space="preserve"><value>حذف الحساب</value></data>
  <data name="Profile_UpdateSuccess" xml:space="preserve"><value>تم تحديث الملف الشخصي بنجاح!</value></data>

  <!-- Account Settings -->
  <data name="Settings_Title" xml:space="preserve"><value>إعدادات الحساب</value></data>
  <data name="Settings_Privacy" xml:space="preserve"><value>إعدادات الخصوصية</value></data>
  <data name="Settings_Notifications" xml:space="preserve"><value>تفضيلات الإشعارات</value></data>
  <data name="Settings_SaveChanges" xml:space="preserve"><value>حفظ التغييرات</value></data>
  <data name="Settings_ChangesSaved" xml:space="preserve"><value>تم حفظ التغييرات بنجاح!</value></data>

</root>
```

---

## ValidationResource.resx (English Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Required Field Validation -->
  <data name="Val_Required" xml:space="preserve"><value>This field is required.</value></data>
  <data name="Val_RequiredField" xml:space="preserve"><value>{0} is required.</value></data>

  <!-- Email Validation -->
  <data name="Val_InvalidEmail" xml:space="preserve"><value>Please enter a valid email address.</value></data>
  <data name="Val_EmailRequired" xml:space="preserve"><value>Email is required.</value></data>

  <!-- Length Validation -->
  <data name="Val_MinLength" xml:space="preserve"><value>Must be at least {0} characters.</value></data>
  <data name="Val_MaxLength" xml:space="preserve"><value>Cannot exceed {0} characters.</value></data>
  <data name="Val_StringLength" xml:space="preserve"><value>Must be between {0} and {1} characters.</value></data>

  <!-- Number Validation -->
  <data name="Val_InvalidNumber" xml:space="preserve"><value>Please enter a valid number.</value></data>
  <data name="Val_Range" xml:space="preserve"><value>Value must be between {0} and {1}.</value></data>

  <!-- Pattern/Format Validation -->
  <data name="Val_InvalidFormat" xml:space="preserve"><value>Invalid format.</value></data>
  <data name="Val_InvalidPhone" xml:space="preserve"><value>Please enter a valid phone number.</value></data>
  <data name="Val_InvalidUrl" xml:space="preserve"><value>Please enter a valid URL.</value></data>

  <!-- Password Validation -->
  <data name="Val_PasswordWeak" xml:space="preserve"><value>Password is too weak.</value></data>
  <data name="Val_PasswordMismatch" xml:space="preserve"><value>Passwords do not match.</value></data>
  <data name="Val_PasswordRequirements" xml:space="preserve"><value>Password must contain uppercase, lowercase, numbers, and special characters.</value></data>

  <!-- Comparison Validation -->
  <data name="Val_Compare" xml:space="preserve"><value>{0} and {1} do not match.</value></data>

  <!-- Unique/Duplicate Validation -->
  <data name="Val_Duplicate" xml:space="preserve"><value>This {0} already exists.</value></data>
  <data name="Val_EmailExists" xml:space="preserve"><value>Email already registered.</value></data>
  <data name="Val_UsernameTaken" xml:space="preserve"><value>Username already taken.</value></data>

  <!-- Not Found Validation -->
  <data name="Val_NotFound" xml:space="preserve"><value>{0} not found.</value></data>

  <!-- Authorization Validation -->
  <data name="Val_Unauthorized" xml:space="preserve"><value>You are not authorized to perform this action.</value></data>
  <data name="Val_AccessDenied" xml:space="preserve"><value>Access denied.</value></data>

  <!-- Custom Business Validation -->
  <data name="Val_InvalidState" xml:space="preserve"><value>Invalid state for this operation.</value></data>
  <data name="Val_OperationNotAllowed" xml:space="preserve"><value>This operation is not allowed.</value></data>

</root>
```

---

## ValidationResource.ar.resx (Arabic Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- Required Field Validation -->
  <data name="Val_Required" xml:space="preserve"><value>هذا الحقل مطلوب.</value></data>
  <data name="Val_RequiredField" xml:space="preserve"><value>{0} مطلوب.</value></data>

  <!-- Email Validation -->
  <data name="Val_InvalidEmail" xml:space="preserve"><value>يرجى إدخال عنوان بريد إلكتروني صحيح.</value></data>
  <data name="Val_EmailRequired" xml:space="preserve"><value>البريد الإلكتروني مطلوب.</value></data>

  <!-- Length Validation -->
  <data name="Val_MinLength" xml:space="preserve"><value>يجب أن يكون على الأقل {0} أحرف.</value></data>
  <data name="Val_MaxLength" xml:space="preserve"><value>لا يمكن أن يتجاوز {0} أحرف.</value></data>
  <data name="Val_StringLength" xml:space="preserve"><value>يجب أن يكون بين {0} و {1} أحرف.</value></data>

  <!-- Number Validation -->
  <data name="Val_InvalidNumber" xml:space="preserve"><value>يرجى إدخال رقم صحيح.</value></data>
  <data name="Val_Range" xml:space="preserve"><value>القيمة يجب أن تكون بين {0} و {1}.</value></data>

  <!-- Pattern/Format Validation -->
  <data name="Val_InvalidFormat" xml:space="preserve"><value>صيغة غير صحيحة.</value></data>
  <data name="Val_InvalidPhone" xml:space="preserve"><value>يرجى إدخال رقم هاتف صحيح.</value></data>
  <data name="Val_InvalidUrl" xml:space="preserve"><value>يرجى إدخال URL صحيح.</value></data>

  <!-- Password Validation -->
  <data name="Val_PasswordWeak" xml:space="preserve"><value>كلمة المرور ضعيفة جداً.</value></data>
  <data name="Val_PasswordMismatch" xml:space="preserve"><value>كلمات المرور غير متطابقة.</value></data>
  <data name="Val_PasswordRequirements" xml:space="preserve"><value>يجب أن تحتوي كلمة المرور على أحرف كبيرة وصغيرة وأرقام وأحرف خاصة.</value></data>

  <!-- Comparison Validation -->
  <data name="Val_Compare" xml:space="preserve"><value>{0} و {1} غير متطابقين.</value></data>

  <!-- Unique/Duplicate Validation -->
  <data name="Val_Duplicate" xml:space="preserve"><value>هذا {0} موجود بالفعل.</value></data>
  <data name="Val_EmailExists" xml:space="preserve"><value>البريد الإلكتروني مسجل بالفعل.</value></data>
  <data name="Val_UsernameTaken" xml:space="preserve"><value>اسم المستخدم مأخوذ بالفعل.</value></data>

  <!-- Not Found Validation -->
  <data name="Val_NotFound" xml:space="preserve"><value>{0} غير موجود.</value></data>

  <!-- Authorization Validation -->
  <data name="Val_Unauthorized" xml:space="preserve"><value>أنت غير مخول لإجراء هذا الإجراء.</value></data>
  <data name="Val_AccessDenied" xml:space="preserve"><value>تم رفض الوصول.</value></data>

  <!-- Custom Business Validation -->
  <data name="Val_InvalidState" xml:space="preserve"><value>حالة غير صحيحة لهذه العملية.</value></data>
  <data name="Val_OperationNotAllowed" xml:space="preserve"><value>هذه العملية غير مسموحة.</value></data>

</root>
```

---

## ErrorResource.resx (English Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- 404 Errors -->
  <data name="Error_404_Title" xml:space="preserve"><value>Page Not Found</value></data>
  <data name="Error_404_Description" xml:space="preserve"><value>The page you're looking for doesn't exist or has been moved.</value></data>
  <data name="Error_404_GoHome" xml:space="preserve"><value>Go to Homepage</value></data>
  <data name="Error_404_GoBack" xml:space="preserve"><value>Go Back</value></data>

  <!-- 500 Errors -->
  <data name="Error_500_Title" xml:space="preserve"><value>Server Error</value></data>
  <data name="Error_500_Description" xml:space="preserve"><value>Something went wrong on our end. Please try again later.</value></data>
  <data name="Error_500_Support" xml:space="preserve"><value>Contact Support</value></data>

  <!-- 403 Errors -->
  <data name="Error_403_Title" xml:space="preserve"><value>Access Denied</value></data>
  <data name="Error_403_Description" xml:space="preserve"><value>You don't have permission to access this resource.</value></data>
  <data name="Error_403_GoHome" xml:space="preserve"><value>Return Home</value></data>

  <!-- 401 Errors -->
  <data name="Error_401_Title" xml:space="preserve"><value>Unauthorized</value></data>
  <data name="Error_401_Description" xml:space="preserve"><value>You must sign in to view this page.</value></data>
  <data name="Error_401_SignIn" xml:space="preserve"><value>Sign In</value></data>

  <!-- Generic Errors -->
  <data name="Error_Generic" xml:space="preserve"><value>An error occurred. Please try again.</value></data>
  <data name="Error_Timeout" xml:space="preserve"><value>The request took too long. Please try again.</value></data>
  <data name="Error_NoConnection" xml:space="preserve"><value>No internet connection. Please check your network.</value></data>
  <data name="Error_BadRequest" xml:space="preserve"><value>Bad request. Please check your input.</value></data>

  <!-- Operation Errors -->
  <data name="Error_DeleteFailed" xml:space="preserve"><value>Failed to delete {0}.</value></data>
  <data name="Error_CreateFailed" xml:space="preserve"><value>Failed to create {0}.</value></data>
  <data name="Error_UpdateFailed" xml:space="preserve"><value>Failed to update {0}.</value></data>
  <data name="Error_LoadFailed" xml:space="preserve"><value>Failed to load {0}.</value></data>

  <!-- Database Errors -->
  <data name="Error_DatabaseError" xml:space="preserve"><value>A database error occurred. Please try again later.</value></data>
  <data name="Error_ValidationFailed" xml:space="preserve"><value>Validation failed. Please check your input.</value></data>

</root>
```

---

## ErrorResource.ar.resx (Arabic Template)

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>
  <resheader name="version"><value>2.0</value></resheader>
  <resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>
  <resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value></resheader>

  <!-- 404 Errors -->
  <data name="Error_404_Title" xml:space="preserve"><value>الصفحة غير موجودة</value></data>
  <data name="Error_404_Description" xml:space="preserve"><value>الصفحة التي تبحث عنها غير موجودة أو تم نقلها.</value></data>
  <data name="Error_404_GoHome" xml:space="preserve"><value>العودة إلى الرئيسية</value></data>
  <data name="Error_404_GoBack" xml:space="preserve"><value>العودة للخلف</value></data>

  <!-- 500 Errors -->
  <data name="Error_500_Title" xml:space="preserve"><value>خطأ في السيرفر</value></data>
  <data name="Error_500_Description" xml:space="preserve"><value>حدث خطأ ما. يرجى المحاولة لاحقاً.</value></data>
  <data name="Error_500_Support" xml:space="preserve"><value>التواصل بالدعم</value></data>

  <!-- 403 Errors -->
  <data name="Error_403_Title" xml:space="preserve"><value>الوصول مرفوض</value></data>
  <data name="Error_403_Description" xml:space="preserve"><value>ليس لديك صلاحية للوصول إلى هذا المورد.</value></data>
  <data name="Error_403_GoHome" xml:space="preserve"><value>العودة للرئيسية</value></data>

  <!-- 401 Errors -->
  <data name="Error_401_Title" xml:space="preserve"><value>غير مخول</value></data>
  <data name="Error_401_Description" xml:space="preserve"><value>يجب تسجيل الدخول لعرض هذه الصفحة.</value></data>
  <data name="Error_401_SignIn" xml:space="preserve"><value>تسجيل الدخول</value></data>

  <!-- Generic Errors -->
  <data name="Error_Generic" xml:space="preserve"><value>حدث خطأ. يرجى المحاولة مرة أخرى.</value></data>
  <data name="Error_Timeout" xml:space="preserve"><value>استغرقت الطلب وقتاً طويلاً. يرجى المحاولة مرة أخرى.</value></data>
  <data name="Error_NoConnection" xml:space="preserve"><value>لا توجد اتصال بالإنترنت. يرجى التحقق من الشبكة.</value></data>
  <data name="Error_BadRequest" xml:space="preserve"><value>طلب غير صحيح. يرجى التحقق من المدخلات.</value></data>

  <!-- Operation Errors -->
  <data name="Error_DeleteFailed" xml:space="preserve"><value>فشل حذف {0}.</value></data>
  <data name="Error_CreateFailed" xml:space="preserve"><value>فشل إنشاء {0}.</value></data>
  <data name="Error_UpdateFailed" xml:space="preserve"><value>فشل تحديث {0}.</value></data>
  <data name="Error_LoadFailed" xml:space="preserve"><value>فشل تحميل {0}.</value></data>

  <!-- Database Errors -->
  <data name="Error_DatabaseError" xml:space="preserve"><value>حدث خطأ في قاعدة البيانات. يرجى المحاولة لاحقاً.</value></data>
  <data name="Error_ValidationFailed" xml:space="preserve"><value>فشلت عملية التحقق. يرجى التحقق من المدخلات.</value></data>

</root>
```

---

## How to Use These Templates

1. **Copy the XML content** for the language you want to create
2. **Create a new `.resx` file** in `MostafaSaidPortfolio/Resources/` with the correct name
3. **Paste the template content** into the file
4. **Edit the values** as needed for your application
5. **Save and rebuild** the project
6. **Verify in views** that the new strings are available

## Important Notes

- Keep the XML structure exactly as shown (don't change headers)
- Use `xml:space="preserve"` on all `<data>` elements to preserve formatting
- Ensure file encoding is **UTF-8**
- Key names must be consistent between EN and AR versions
- Always include parameter placeholders (`{0}`, `{1}`, etc.) where applicable

---

## Next Steps

1. Create these five resource files in `Resources/` folder
2. Update `Program.cs` to register them if needed
3. Update `_ViewImports.cshtml` to inject all localizers
4. Gradually migrate existing hard-coded strings to use these resources
5. Update forms to use proper localized labels and validation messages
