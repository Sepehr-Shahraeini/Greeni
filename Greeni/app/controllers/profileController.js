﻿'use strict';
app.controller('profileController', ['$scope', '$rootScope', '$location', '$routeParams', 'personService', 'authService', function($scope, $rootScope, $location, $routeParams, personService, authService,) {


    //وقتی از این مدل چیزا استفاده می کنی:
    //$routeParams
    //باید اون بالا اضافه شده باشه
    $scope.profileId = $routeParams.id;
   
    //این کس شعرایی که کامنت کردم چیه؟
   // var $jq = jQuery.noConflict();
    //عرضم به درزت  که این برای مقایسه دوتا پسورد هست   
    //البته الان بعد از اضافه کردن یک تکست باکس دیگه کلا گیر میده

    $scope.entity = {
        Id:$scope.profileId,
 Name:null,
 Address:null,
 Phone:null,
 Email:null,
 Website:null,
 Url:null,
  
 Twitter:null,
 LinkedIn:null,
 ImageUrl:null,
 
  
 ZIPCode:null,
 City:null,
 State:null,
  
  
  
 Remark:null,
 FirstName:null,
 LastName:null,
 Mobile:null,
 Phone2:null,
 Phone3:null,
 NID:null,

    };
    $scope.entityPassword = {
        Password: null,
        Old: null,
        ConfirmPassword: null,
        UserName: $rootScope.userName
    };

    

    $scope.txt_FirstName = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'نام',
        rtlEnabled: true,
        bindingOptions: {
            value: "entity.FirstName",

        }
    };

    $scope.txt_LastName = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: ' نام خانوادگی',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.LastName',

        }
    };

    $scope.txt_Company = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: ' فروشگاه',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.Name'

        }
    };

    $scope.txt_Address = {
        hoverStateEnabled: false,
        width: '100%',
        height: 90,
        placeholder: ' آدرس',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.Address',

        }
    };

    $scope.txt_MailCode = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'کد پستی',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.ZIPCode',

        }
    };

    $scope.txt_CodeMeli = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: ' کد ملی',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.NID',

        }
    };

    $scope.txt_Phone = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'تلفن',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.Phone',

        }
    };

    $scope.txt_Mobile = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'تلفن همراه ',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.Mobile',

        }
    };

    $scope.txt_Email = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: ' ایمیل',
        rtlEnabled: true,
        bindingOptions: {
            value: 'entity.Email',

        }
    };

    $scope.txt_Password = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'کلمه عبور',
        mode: "password",
        rtlEnabled: true,
        bindingOptions: {
            value: 'entityPassword.Password',

        }
    };

    $scope.txt_ConfirmPassword = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'تکرار کلمه عبور',
        mode: "password",
        rtlEnabled: true,
        bindingOptions: {
            value: 'entityPassword.ConfirmPassword',

        }
    };

    $scope.txt_currentPassword = {
        hoverStateEnabled: false,
        width: '100%',
        height: 45,
        placeholder: 'کلمه عبور فعلی',
        mode: "password",
        rtlEnabled: true,
        bindingOptions: {
            value: 'entityPassword.Old',

        }
    };


    $scope.passwordValidationRules = {
        validationGroup: 'profile_password',
        validationRules: [{

            type: "required",
            message: "این فیلد ضروری است"
        }]
    };

    //این اضافه شد
    $scope.currentPasswordValidationRules = {
        validationGroup: 'profile_password',
        validationRules: [{

            type: "required",
            message: "این فیلد ضروری است"
        }]
    };

    $scope.confirmPasswordValidationRules = {
        validationGroup: 'profile_password',
        validationRules: [{

            type: "compare",
            comparisonTarget: function () {
                var password = $("#password-validation-profile").dxTextBox("instance");
                if (password) {
                    return password.option("value");
                }
            },
            message: "کلمه عبور اشتباه است"
        },
        {
            type: "required",
            message: "این فیلد ضروری است"
        }]
    };




    $scope.btn_save = {
        text: 'تایید',
        type: 'success',
        icon: 'check',
        width: '100%',
        height: 45,
        rtlEnabled: true,
        validationGroup: 'profileupdate',
        onClick: function (e) {
            
            var result = e.validationGroup.validate();

            if (!result.isValid) {
                alert('لطفا اطلاعات خواسته شده را کامل کنید');
                return;

            }
            /////////
            $scope.loadingVisible = true;
            authService.updateCompany($scope.entity).then(function (response) {

                $rootScope.userName =$scope.entity.Mobile;
                $scope.loadingVisible = false;
                General.ShowNotify('تغییرات با موفقیت ذخیره شد', 'success');
                
                
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
            ///////////////////
        }

    };


    $scope.btn_password = {
        text: 'تایید',
        type: 'success',
        icon: 'check',
        width: '100%',
        height: 45,
        rtlEnabled: true,
        validationGroup: 'profile_password',
        onClick: function (e) {
            var result = e.validationGroup.validate();

            if (!result.isValid) {

                return;
            }

           
            $scope.loadingVisible = true;
            authService.changePassword($scope.entityPassword).then(function (response) {

                // General.ShowNotify(Config.Text_SavedOk, 'success');
                $scope.loadingVisible = false;
                General.ShowNotify('تغییرات با موفقیت ذخیره شد', 'success');
                $scope.entityPassword.Old = null;
                $scope.entityPassword.Password = null;
                $scope.entityPassword.ConfirmPassword = null;
                
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
            ////////////////////

           
            ////////////

            
           
        }
    };






    /////////////////////////////////////////
    $scope.loadingVisible = false;
    $scope.loadPanel = {
        message: 'لطفا صبر کنید',
        rtlEnabled: true,
        showIndicator: true,
        showPane: true,
        shading: true,
        closeOnOutsideClick: false,
        shadingColor: "rgba(0,0,0,0.4)",
        // position: { of: "body" },
        onShown: function () {

        },
        onHidden: function () {

        },
        bindingOptions: {
            visible: 'loadingVisible'
        }
    };

    ////////////////////////////////////////////
    $scope.bind = function () {
        $scope.loadingVisible = true;
        personService.getCompany($scope.profileId).then(function (result) {
            $scope.loadingVisible = false;

            $scope.entity.Mobile = result.Mobile;
            $scope.entity.FirstName = result.FirstName;
            $scope.entity.LastName = result.LastName;
            $scope.entity.Email = result.Email;
            $scope.entity.Address = result.Address;
            $scope.entity.ZIPCode = result.ZIPCode;
            $scope.entity.NID = result.NID;
            $scope.entity.Phone = result.Phone;
            $scope.entity.Name = result.Name;
            //console.log(result);


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    }

    $scope.bind();
    ////////////////////////////////////////////




}]);