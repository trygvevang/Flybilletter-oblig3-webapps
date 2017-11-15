import { Component, OnInit } from "@angular/core";
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
    templateUrl: "./app/Content.html"
})

export class Content {
    showFAQ: boolean;
    submitQ: boolean;
    allQuestions: Array<Question>;
    allCategories: Array<QuestionCategory>;
    form: FormGroup;
    loading: boolean;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.form = fb.group({
            ID: [""],
            Firstname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Lastname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Email: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z0-9 -_.]+@[a-zA-Z]+.[a-zA-Z]{2,3}$")])],
            Question: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ .]{2,}[?]$")])],
            Category: [null, Validators.compose([Validators.required, Validators.pattern("[0,9]{1,2}")])]
        });
    }

    ngOnInit() {
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.getAll();
        this.getAllCategories();
    }

    getAll() {
        this._http.get("api/Question")
            .map(data => {
                let jsonData = data.json();
                return jsonData;
            })
            .subscribe(jsonData => {
                this.allQuestions = [];
                if (jsonData) {
                    for (let question of jsonData) {
                        this.allQuestions.push(question);
                    }
                    console.log(this.allQuestions);
                    this.loading = false;
                }
            },
            error => alert(error), () => console.log("All questions loaded (get-api/Question)."));
    }

    getAllCategories() {
        this._http.get("api/QuestionCategory")
            .map(data => {
                let jsonData = data.json();
                return jsonData;
            })
            .subscribe(jsonData => {
                this.allCategories = [];
                if (jsonData) {
                    for (let questType of jsonData) {
                        this.allCategories.push(questType);
                    }
                    this.loading = false;
                }
            },
            error => alert(error), () => console.log("All questions loaded (get-api/QuestionCategory)."));
    }

    showQuestionForm() {
        this.form.setValue({ // Reseting form just in case there were some changes there before.
            ID: "",
            Firstname: "",
            Lastname: "",
            Email: "",
            Question: "",
            Category: ""
        });
        this.form.markAsPristine();
        this.showFAQ = false;
        this.submitQ = true;
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

        console.log(body);
        this._http.post("api/Question", body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.getAll();
                this.getAllCategories();
                this.submitQ = false;
                this.showFAQ = true;
            },
            error => alert(error),
            () => console.log("Question submitted (post-api/Question)")
            );
    }
}