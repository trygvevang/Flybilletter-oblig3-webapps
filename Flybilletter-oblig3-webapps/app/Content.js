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
var http_2 = require("@angular/http");
var Question_1 = require("./Question");
var Person_1 = require("./Person");
var Content = (function () {
    function Content(_http, fb) {
        this._http = _http;
        this.fb = fb;
        this.form = fb.group({
            ID: [""],
            Firstname: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Lastname: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Question: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-ZøæåØÆÅ ]{2,}[?]$")])],
            QuestionType: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("[0,9]{1,2}")])]
        });
    }
    Content.prototype.ngOnInit = function () {
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.getAll();
        this.getAllQuestionTypes();
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
    Content.prototype.getAllQuestionTypes = function () {
        var _this = this;
        this._http.get("api/QuestionType")
            .map(function (data) {
            var jsonData = data.json();
            return jsonData;
        })
            .subscribe(function (jsonData) {
            _this.allQuestionTypes = [];
            if (jsonData) {
                for (var _i = 0, jsonData_2 = jsonData; _i < jsonData_2.length; _i++) {
                    var questType = jsonData_2[_i];
                    _this.allQuestionTypes.push(questType);
                }
                _this.loading = false;
            }
        }, function (error) { return alert(error); }, function () { return console.log("All questions loaded (get-api/QuestionType)."); });
    };
    Content.prototype.showQuestionForm = function () {
        this.form.setValue({
            ID: "",
            Firstname: "",
            Lastname: "",
            Question: "",
            QuestionType: ""
        });
        this.form.markAsPristine();
        this.showFAQ = false;
        this.submitQ = true;
    };
    Content.prototype.submitQuestion = function () {
        var _this = this;
        var person = new Person_1.Person();
        person.Firstname = this.form.value.Firstname;
        person.Lastname = this.form.value.Lastname;
        var questionType = this.form.value.QuestionType;
        var question = new Question_1.Question();
        question.Quest = this.form.value.Question;
        question.Person = person;
        question.QuestionType = questionType;
        var body = JSON.stringify(question);
        var headers = new http_2.Headers({ "Content-Type": "application/json" });
        console.log(body);
        this._http.post("api/Question", body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.getAll();
            _this.getAllQuestionTypes();
            _this.submitQ = false;
            _this.showFAQ = true;
        }, function (error) { return alert(error); }, function () { return console.log("Question submitted (post-api/Question)"); });
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