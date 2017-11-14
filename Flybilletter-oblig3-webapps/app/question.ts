import { Person } from './Person';
import { QuestionCategory } from './QuestionCategory';

export class Question {
    ID: number;
    Person: Person;
    Quest: string;
    Category: QuestionCategory; //Question is string so backend can validate if category exists or not.
    Answer: string;
}

export class QuestionData {
    ID: number;
    Person: Person;
    Quest: string;
    QuestionCategory: string;
    Answer: string;
}