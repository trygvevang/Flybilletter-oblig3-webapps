import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'SearchPipe',
})
export class SearchPipe implements PipeTransform {
    transform(questions: any[], keyword: string): any[] {
        if (!questions) return [];
        if (!keyword) return questions;
        return questions.filter(function (pipe) {
            return pipe.Quest.toLowerCase().indexOf(keyword.toLowerCase()) > -1;
        })
    }
}