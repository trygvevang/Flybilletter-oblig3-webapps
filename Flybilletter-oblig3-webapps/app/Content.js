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
var Question_2 = require("./Question");
var Person_1 = require("./Person");
var Content = (function () {
    function Content(_http, fb) {
        this._http = _http;
        this.fb = fb;
        this.form = fb.group({
            ID: [""],
            Firstname: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-ZøæåØÆÅ\\-. ]{2,30}$")])],
            Lastname: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-ZøæåØÆÅ\\-. ]{2,30}$")])],
            Email: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-Z0-9 -_.]+@[a-zA-Z]+.[a-zA-Z]{2,3}$")])],
            Question: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-ZøæåØÆÅ .,0-9\n]{2,}[?]$")])],
            Category: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[0-9]{1,2}$")])]
        });
        this.answerForm = new forms_1.FormGroup({
            Answer: new forms_1.FormControl([null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-Z0-9øæåØÆÅ .,!-]{2,}$")])])
        });
    }
    Content.prototype.ngOnInit = function () {
        this.keyword = '';
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.showUnansweredUserQuestion = false;
        this.isAnsweringQuestion = false;
        this.getAllCategories();
    };
    Content.prototype.getAllCategories = function () {
        var _this = this;
        this._http.get("api/QuestionCategory")
            .map(function (data) {
            var jsonData = data.json();
            return jsonData;
        })
            .subscribe(function (jsonData) {
            _this.allCategories = [];
            _this.answeredQuestions = [];
            _this.unansweredQuestions = [];
            if (jsonData) {
                for (var _i = 0, jsonData_1 = jsonData; _i < jsonData_1.length; _i++) {
                    var questCat = jsonData_1[_i];
                    _this.allCategories.push(questCat);
                    if (questCat.Questions)
                        for (var _a = 0, _b = questCat.Questions; _a < _b.length; _a++) {
                            var question = _b[_a];
                            if (question.Answer)
                                _this.answeredQuestions.push(question);
                            else
                                _this.unansweredQuestions.push(question);
                        }
                }
                _this.loading = false;
            }
        }, function (error) { return alert(error); }, function () { return console.log("All questions loaded (get-api/QuestionCategory)."); });
    };
    Content.prototype.resetQuestionForm = function () {
        this.form.setValue({
            ID: "",
            Firstname: "",
            Lastname: "",
            Email: "",
            Question: "",
            Category: ""
        });
    };
    Content.prototype.showQuestionForm = function () {
        this.resetQuestionForm();
        this.form.markAsPristine();
        this.showFAQ = false;
        this.submitQ = true;
        this.showUnansweredUserQuestion = false;
    };
    Content.prototype.showUnanswered = function () {
        this.showUnansweredUserQuestion = true;
        this.showFAQ = false;
        this.submitQ = false;
    };
    Content.prototype.showFaq = function () {
        this.resetQuestionForm();
        this.showFAQ = true;
        this.showUnansweredUserQuestion = false;
        this.submitQ = false;
    };
    Content.prototype.submitQuestion = function () {
        var _this = this;
        var person = new Person_1.Person();
        person.Firstname = this.form.value.Firstname;
        person.Lastname = this.form.value.Lastname;
        person.Email = this.form.value.Email;
        var category = this.form.value.Category;
        var question = new Question_2.QuestionData();
        question.Quest = this.form.value.Question;
        question.Person = person;
        question.Category = category;
        var body = JSON.stringify(question);
        var headers = new http_2.Headers({ "Content-Type": "application/json" });
        this._http.post("api/Question", body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.getAllCategories();
            _this.submitQ = false;
            _this.showFAQ = true;
        }, function (error) { return alert(error); }, function () { return console.log("Question submitted (post-api/Question)"); });
        this.getAllCategories();
    };
    Content.prototype.showAnswerQForm = function () {
        this.answerForm.setValue({
            Answer: ""
        });
        this.answerForm.markAsPristine();
        this.isAnsweringQuestion = true;
    };
    Content.prototype.answerQuestion = function (question) {
        var _this = this;
        this.isAnsweringQuestion = false;
        var changedQuestion = new Question_1.Question();
        changedQuestion.ID = question.ID;
        changedQuestion.Person = question.Person;
        changedQuestion.Quest = question.Quest;
        changedQuestion.Answer = this.answerForm.value.Answer;
        var body = JSON.stringify(changedQuestion);
        var headers = new http_2.Headers({ "Content-Type": "application/json" });
        this._http.put("api/Question/" + question.ID, body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.getAllCategories();
        }, function (error) { return alert(error); }, function () { return console.log("Question answered (post-api/Question)"); });
        this.answerForm.setValue({
            Answer: ""
        });
        this.getAllCategories();
    };
    return Content;
}());
Content = __decorate([
    core_1.Component({
        selector: "application",
        templateUrl: "./app/Content.html",
    }),
    __metadata("design:paramtypes", [http_1.Http, forms_1.FormBuilder])
], Content);
exports.Content = Content;
//# sourceMappingURL=Content.js.map