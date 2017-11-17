import { Person } from './Person';
import { QuestionCategory } from './QuestionCategory';

export class Question {
    ID: number;
    Person: Person;
    Quest: string;
    Answer: string;
}

export class QuestionData {
    Person: Person;
    Quest: string;
    Category: string;
    Answer: string;
}