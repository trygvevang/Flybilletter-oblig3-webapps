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
var Search = (function () {
    function Search() {
        this.keyword = '';
        /*
        whenSubmit() {
            // Get all questions that contain keyword-parameter
            if (this.searchQuestion.value.Keyword) {
                this.keyword = this.searchQuestion.value.Keyword;
                this.get(this.searchQuestion.value.Keyword);
            }
        }
    
        get(keyword: string) {
            this._http.get("api/Question/" + keyword)
                .map(returnData => {
                    return returnData.json();
                })
                .subscribe(jsonData => {
                    this.allQuest = [];
                    if (jsonData) {
                        for (let quest of jsonData) {
                            this.allQuest.push(quest);
                        }
                    }
                }, error => alert(error),
                () => console.log("All questions containing " + keyword + " loaded (get-api/Question/keyword)"));
        } */
    }
    Search.prototype.ngOnInit = function () {
    };
    Search.prototype.questions = function (array) {
        return Array.from(array);
    };
    return Search;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], Search.prototype, "allQuestions", void 0);
Search = __decorate([
    core_1.Component({
        selector: 'spa-search',
        template: "\n                <input class=\"form-control\" [(ngModel)]=\"keyword\" type=\"text\" placeholder=\"S\u00F8k etter sp\u00F8rsm\u00E5l\" />\n                <div *ngIf=\"keyword\" class=\"list-group\">\n                    <div class=\"list-group-item row_div_parent\">\n                        <h4 class=\"panel-title\">Sp\u00F8rsm\u00E5l som inneholder \"{{keyword}}\"</h4><!--if keyword is nonsense (like space or a .) then display something else-->\n                        <div class=\"container\" *ngFor=\"let question of questions(allQuestions)\"> <!-- Bruk pipes for \u00E5 filtrere basert p\u00E5 keyword -->\n                            {{keyword}}\n                            {{question.Quest}}\n                            <a data-toggle=\"collapse\" href=\"#{{question.ID + '_search'}}\">{{question.Quest}}</a>\n                            <div class=\"collapse\" id=\"{{question.ID + '_search'}}\">\n                                Svar: {{question.Answer}}\n                            </div>\n                        </div>\n                    </div>\n                </div>\n               "
    })
], Search);
exports.Search = Search;
//# sourceMappingURL=search.js.map