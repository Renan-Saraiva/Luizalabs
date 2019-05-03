angular.module('EmployeeManager').controller('EmployeeController', ['$scope',  "EmployeeService",
    function ($scope, EmployeeService) {

        $scope.isLoading = false;

        $scope.employees = [];

        $scope.prospectEmployeeToDelete = {};

        $scope.currentEmployee = {};

        $scope.openModal = function (employee) {        
            if (employee)
                $scope.currentEmployee = angular.copy(employee);
            else
                $scope.currentEmployee = { id: 0, name: "", email: "", department: "" };
        };

        $scope.save = function (employeeForm) {
            $scope.currentEmployee.id === 0 ? $scope.add($scope.currentEmployee) : $scope.update($scope.currentEmployee);            
            $scope.resetForm();
        };

        $scope.add = function (employee) {
            EmployeeService.post(employee)
                .then(function (response) {
                    employee.id = response.data;
                    $scope.employees.push(employee);
                })
                .catch(function (err) {
                    console.error(err);
                });
        };

        $scope.update = function (employee) {
            EmployeeService.put(employee)
                .then(function (response) {
                    angular.copy(employee, $scope.employees.filter(item => item.id === employee.id)[0]);
                })
                .catch(function (err) {
                    console.error(err);
                });
        };

        $scope.openModalDelete = function (employee) {
            $scope.prospectEmployeeToDelete = employee;
        };

        $scope.delete = function () {
            EmployeeService.delete($scope.prospectEmployeeToDelete.id)
                .then(function (response) {
                    $scope.employees = $scope.employees.filter(item => item.id !== $scope.prospectEmployeeToDelete.id);
                })
                .catch(function (err) {
                    console.error(err);
                })
                .finally(function () {
                    $scope.prospectEmployeeToDelete = {};
                });
        };

        $scope.list = function () {
            EmployeeService.list()
                .then(function (response) {
                    $scope.employees = response.data;
                })
                .catch(function (err) {
                    console.error(err);
                });
        };

        $scope.resetForm = function (employeeForm) {
            $scope.currentEmployee = {};
            employeeForm.$setPristine();
            employeeForm.$setUntouched();
        };

        $scope.list();

    }
]);


