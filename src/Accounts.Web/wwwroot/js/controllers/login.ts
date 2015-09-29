﻿/// <reference path="../_all-references.ts" />


module Controllers {
    'use strict';

    export class Login {

        public static $inject = [
            '$scope', '$http'
        ];

        constructor(
            private $scope,
            private $http: ng.IHttpService
        ) {
            $scope.loading = false;
            $scope.error = false;
            $scope.submit = function (url: string) {
                console.log(url);
                $scope.loading = true;
                $http({
                    method: 'POST',
                    url: url,
                    data: $scope.form,
                    headers: { 'Content-Type': 'application/json; charset=utf-8', 'dataType': 'json' }
                    //url, $scope.form, { headers: { 'Content-Type': 'application/json; charset=utf-8', 'dataType': 'json' } }
                })
                    .success(() => {
                        console.log("login com sucesso");
                    })
                    .error(() => {
                        $scope.error = true;
                        console.error("erro na requisição");
                    })
                    .finally(() => {
                        $scope.loading = false;
                    });
            }
        }
    }
}
angular.module('app').controller('LoginController', Controllers.Login)
