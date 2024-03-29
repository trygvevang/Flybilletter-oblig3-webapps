﻿import { Component, OnInit, Pipe, PipeTransform } from "@angular/core";
import { Http, Response } from '@angular/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import "rxjs/add/operator/map";
import {Headers} from "@angular/http";
import { Question } from './Question';
import { QuestionCategory } from './QuestionCategory';
import { QuestionData } from './Question';
import { Person } from './Person';

@Component({
    selector: "application",
    templateUrl: "./app/Content.html",
})

export class Content {
    showFAQ: boolean;
    showUnansweredUserQuestion: boolean;
    submitQ: boolean;
    allCategories: Array<QuestionCategory>;
    answeredQuestions: Array<Question>;
    unansweredQuestions: Array<Question>;
    form: FormGroup;
    answerForm: FormGroup;
    loading: boolean;
    isAnsweringQuestion: boolean;
    keyword: string;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.form = fb.group({
            ID: [""],
            Firstname: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ\\-. ]{2,30}$")])],
            Lastname: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ\\-. ]{2,30}$")])],
            Email: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z0-9 -_.]+@[a-zA-Z]+.[a-zA-Z]{2,3}$")])],
            Question: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ .,0-9\n]{2,}[?]$")])],
            Category: [null, Validators.compose([Validators.required, Validators.pattern("^[0-9]{1,2}$")])]
        });
        this.answerForm = new FormGroup({
            Answer: new FormControl([null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z0-9øæåØÆÅ .,!-]{2,}$")])])
        });
    }

    ngOnInit() {
        this.keyword = '';
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.showUnansweredUserQuestion = false;
        this.isAnsweringQuestion = false;
        this.getAllCategories();
    }
    
    getAllCategories() {
        this._http.get("api/QuestionCategory")
            .map(data => {
                let jsonData = data.json();
                return jsonData;
            })
            .subscribe(jsonData => {
                this.allCategories = [];
                this.answeredQuestions = [];
                this.unansweredQuestions = [];
                if (jsonData) {
                    for (let questCat of jsonData) {
                        this.allCategories.push(questCat);
                        if (questCat.Questions) for (let question of questCat.Questions) {
                            if (question.Answer)
                                this.answeredQuestions.push(question);
                            else this.unansweredQuestions.push(question);
                        }
                    }
                    this.loading = false;
                }
            },
            error => alert(error), () => console.log("All questions loaded (get-api/QuestionCategory)."));
    }

    resetQuestionForm() {
        this.form.setValue({
            ID: "",
            Firstname: "",
            Lastname: "",
            Email: "",
            Question: "",
            Category: ""
        });
    }

    showQuestionForm() {
        this.resetQuestionForm();
        this.form.markAsPristine();
        this.showFAQ = false;
        this.submitQ = true;
        this.showUnansweredUserQuestion = false;
    }

    showUnanswered() {
        this.showUnansweredUserQuestion = true;
        this.showFAQ = false;
        this.submitQ = false;
    }

    showFaq() {
        this.resetQuestionForm();
        this.showFAQ = true;
        this.showUnansweredUserQuestion = false;
        this.submitQ = false;
    }

    submitQuestion() {
        var person = new Person();
        person.Firstname = this.form.value.Firstname;
        person.Lastname = this.form.value.Lastname;
        person.Email = this.form.value.Email;
        
        var category = this.form.value.Category;

        var question = new QuestionData();
        question.Quest = this.form.value.Question;
        question.Person = person;
        question.Category = category;

        var body: string = JSON.stringify(question);
        var headers = new Headers({ "Content-Type": "application/json" });
        
        this._http.post("api/Question", body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.getAllCategories();
                this.submitQ = false;
                this.showFAQ = true;
            },
            error => alert(error),
            () => console.log("Question submitted (post-api/Question)")
        );
        this.getAllCategories();
    }

    showAnswerQForm() {
        this.answerForm.setValue({ 
            Answer: ""
        });
        this.answerForm.markAsPristine();
        this.isAnsweringQuestion = true;
    }

    answerQuestion(question:Question) {
        this.isAnsweringQuestion = false;

        var changedQuestion = new Question();
        changedQuestion.ID = question.ID;
        changedQuestion.Person = question.Person;
        changedQuestion.Quest = question.Quest;
        changedQuestion.Answer = this.answerForm.value.Answer;

        var body: string = JSON.stringify(changedQuestion);
        var headers = new Headers({ "Content-Type": "application/json" });

        this._http.put("api/Question/" + question.ID, body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.getAllCategories();
            },
            error => alert(error),
            () => console.log("Question answered (post-api/Question)")
        );

        this.answerForm.setValue({
            Answer: ""
        });

        this.getAllCategories();
    }
}