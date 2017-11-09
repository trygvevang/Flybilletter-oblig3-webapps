import { Component, OnInit } from "@angular/core";
import { Http, Response } from '@angular/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import "rxjs/add/operator/map";
import {Headers} from "@angular/http";
import { Question } from './Question';

@Component({
    selector: "application",
    templateUrl: "./app/Content.html"
})

export class Content {
    showFAQ: boolean;
    submitQ: boolean;
    allQuestions: Array<Question>;
    form: FormGroup;
    loading: boolean;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.form = fb.group({
            /*ID: [""],
            Firstname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Lastname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Question: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ]{2,}")])],
            QuestionType: [] */
        });
    }

    ngOnInit() {
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.getAll();
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
                    this.loading = false;
                }
            },
            error => alert(error), () => console.log("All questions loaded (get-api/Question)."));
    }
}