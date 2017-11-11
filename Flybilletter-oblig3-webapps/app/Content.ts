import { Component, OnInit } from "@angular/core";
import { Http, Response } from '@angular/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import "rxjs/add/operator/map";
import {Headers} from "@angular/http";
import { Question } from './Question';
import { QuestionType } from './QuestionType';

@Component({
    selector: "application",
    templateUrl: "./app/Content.html"
})

export class Content {
    showFAQ: boolean;
    submitQ: boolean;
    allQuestions: Array<Question>;
    allQuestionTypes: Array<QuestionType>;
    form: FormGroup;
    loading: boolean;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.form = fb.group({
            ID: [""],
            Firstname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Lastname: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            Question: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ]{2,}")])],
            QuestionType: [null, Validators.compose([Validators.required, Validators.pattern("[0,9]{1,2}")])]
        });
    }

    ngOnInit() {
        this.loading = true;
        this.showFAQ = true;
        this.submitQ = false;
        this.getAll();
        this.getAllQuestionTypes();
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

    getAllQuestionTypes() {
        this._http.get("api/QuestionType")
            .map(data => {
                let jsonData = data.json();
                return jsonData;
            })
            .subscribe(jsonData => {
                this.allQuestionTypes = [];
                if (jsonData) {
                    for (let questType of jsonData) {
                        this.allQuestionTypes.push(questType);
                    }
                    this.loading = false;
                }
            },
            error => alert(error), () => console.log("All questions loaded (get-api/QuestionType)."));
    }

    showQuestionForm() {
        this.form.setValue({ // Reseting form just in case there were some changes there before.
            ID: "",
            Firstname: "",
            Lastname: "",
            Question: "",
            QuestionType: ""
        });
        this.form.markAsPristine();
        this.showFAQ = false;
        this.submitQ = true;
    }

    submitQuestion() {
        var question = new Question();
        question.Quest = this.form.value.Question;
        //question.Person = 
        /*
        Lage en entitet Person som bare består av firstname,lastname
        Sende den dataen som personobjektet til server-side
        serverside håndterer dataen, ved å søke etter personen i databasen
            exist = bool med db spørring om person finnes
            if (!exist)
            {
                var kunde = lagKundeBasertPåDataFraWebApp
                db.lagreKunde(kunde)
            }
            var kunde = lagKundeBasertPåDataFraWebApp
            return lagreSpørsmålMedPersonFraDb() // Metode som lagrer kunde returnerer true/false
        */
    }
}