"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
require("rxjs/add/operator/map");
var Content = (function () {
    function Content(_http, fb) {
        this._http = _http;
        this.fb = fb;
        this.form = fb.group({});
    }
    Content.prototype.ngOnInit = function () {
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.getAll();
    };
    Content.prototype.getAll = function () {
        var _this = this;
        this._http.get("api/Question")
            .map(function (data) {
            var jsonData = data.json();
            return jsonData;
        })
            .subscribe(function (jsonData) {
            _this.allQuestions = [];
            if (jsonData) {
                for (var _i = 0, jsonData_1 = jsonData; _i < jsonData_1.length; _i++) {
                    var question = jsonData_1[_i];
                    _this.allQuestions.push(question);
                }
                _this.loading = false;
            }
        }, function (error) { return alert(error); }, function () { return console.log("All questions loaded (get-api/Question)."); });
    };
    return Content;
}());
Content = __decorate([
    core_1.Component({
        selector: "application",
        templateUrl: "./app/Content.html"
    }),
    __metadata("design:paramtypes", [http_1.Http, forms_1.FormBuilder])
], Content);
exports.Content = Content;
//# sourceMappingURL=Content.js.map