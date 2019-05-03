angular.module('EmployeeManager').service('EmployeeService', ['$http',
    function ($http) {

        const httpConfig = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };

        var _list = function () {
            return $http.get('/Employee', httpConfig);
        };

        var _get = function (employeeId) {
            return $http.get('/Employee/' + employeeId, httpConfig);
        };

        var _post = function (employee) {
            return $http.post('/Employee', JSON.stringify(employee), httpConfig);
        };

        var _put = function (employee) {
            return $http.put('/Employee/' + employee.id, JSON.stringify(employee), httpConfig);
        };

        var _delete = function (employeeId) {
            return $http.delete('/Employee/' + employeeId, httpConfig);
        };

        return {
            list: _list,
            get: _get,
            post: _post,
            put: _put,
            delete: _delete
        };
    }
]);