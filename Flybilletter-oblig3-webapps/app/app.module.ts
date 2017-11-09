import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { Content } from './Content';
@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, JsonpModule],
    declarations: [Content],
    bootstrap: [Content]
})
export class AppModule { }
