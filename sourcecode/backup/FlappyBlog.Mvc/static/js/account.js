var accountResources={ 
    passwordIsRequried: "请填写密码",
    emailIsRequired: "请填写 Email",
    emailIsInvalid: "Email 无效",
    userNameIsRequired: "请填写用户名",
    newAndConfirmPasswordMismatch: "新密码与密码确认不一致",
    confirmPasswordIsRequired: "请填写密码确认",
    oldPasswordIsRequired: "请填写原密码",
    newPasswordIsRequired: "请填写新密码",
    passwordAndConfirmPasswordIsMatch: "新密码与密码确认不一致",
    minPassLengthInChars: "密码至少要包含 {0} 个字符"
 }; 
function ShowStatus(status, msg) {
    $("#AdminStatus").removeClass("warning");
    $("#AdminStatus").removeClass("success");

    $("#AdminStatus").addClass(status);
    $("#AdminStatus").html(msg + '<a href="javascript:HideStatus()" style="width:20px;float:right">X</a>');
    $("#AdminStatus").fadeIn(1000, function () { });
}

function HideStatus() {
    $("#AdminStatus").fadeOut('slow', function () { });
}

function Hide(element) {
    $("[id$='" + element + "']").fadeOut('slow', function () { });
    return false;
}

function ValidateLogin() {
    if ($("#userName").val().length == 0) {
        ShowStatus('warning', accountResources.userNameIsRequired);
        return false;
    }
    if ($("#password").val().length == 0) {
        ShowStatus('warning', accountResources.passwordIsRequried);
        return false;
    }
    return true;
}

function ValidatePasswordRetrieval() {
    if ($("#txtEmail").val().length == 0) {
        ShowStatus('warning', accountResources.emailIsRequired);
        return false;
    }
    if (ValidateEmail($("#txtEmail").val()) == false) {
        ShowStatus('warning', accountResources.emailIsInvalid);
        return false;
    }
    return true;
}

function ValidateEmail(email) {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    return reg.test(email);
}

$(document).ready(function () {
    $(":checkbox").bootstrapSwitch();
    $("#userName").focus();
    $(".account-header").animate({
        top: 0,
        opacity: 1,
    }, 1000);
    $(".account").animate({
        top: 0,
        opacity: 1,
    }, 1000);
});