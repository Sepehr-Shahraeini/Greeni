﻿'use strict';
app.factory('orderService', ['$http', '$q',   '$rootScope', function ($http, $q,   $rootScope) {



    var serviceFactory = {};

    var _getOrders = function (mobile) {


        var deferred = $q.defer();
        $http.get(serviceBase + 'api/orders/' + mobile).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getOrdersByUser = function (userid) {


        var deferred = $q.defer();
        $http.get(serviceBase + 'api/orders/user/' + userid).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _getOrderItems = function (Id) {


        var deferred = $q.defer();
        $http.get(serviceBase + 'api/order/Items/' + Id).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _sendSMS = function (entity) {
        //https://api.kavenegar.com/v1/613472435563797A3767733D/verify/lookup.json?receptor=09361234567&token=852596&template=myverification

        var deferred = $q.defer();
        $http.get(serviceBase + 'api/orders/' + mobile).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    

    var _save = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'api/orders/save', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
     
 
    var _getOrderById = function (Id) {


        var deferred = $q.defer();
        $http.get(serviceBase + 'api/orders/id/' + Id).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };



    serviceFactory.save = _save;
    serviceFactory.getOrders = _getOrders;
    serviceFactory.getOrdersByUser = _getOrdersByUser;
    serviceFactory.getOrderItems = _getOrderItems;
    serviceFactory.getOrderById = _getOrderById;
    return serviceFactory;

}]);