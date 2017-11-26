import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'SearchPipe',
})
export class SearchPipe implements PipeTransform {
    transform(items: any[], value: string): any[] {
        console.log(items);
        console.log(value);
        if (!items) return [];
        if (!value) return items;
        return items.filter(function (pipe) {
            return pipe.Quest.toLowerCase().indexOf(value.toLowerCase()) > -1;
        })
    }
}