import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { Content } from './Content';
import { SearchPipe } from './SearchPipe';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, JsonpModule, FormsModule],
    declarations: [Content, SearchPipe],
    bootstrap: [Content]
})
export class AppModule { }
