import { Person } from './Person';
import { QuestionType } from './QuestionType';
export class Question {
    ID: number;
    Person: Person;
    Quest: string;
    QuestionType: QuestionType;
    Answer: string;
}