//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IBooksClient {
    getBooksWithPagination(searchCriteria: string | null, pageNumber: number, pageSize: number): Observable<PaginatedListOfBookDto>;
    createBook(command: CreateBookCommand): Observable<number>;
    updateBook(id: number, command: UpdateBookCommand): Observable<void>;
    deleteBook(id: number): Observable<void>;
}

@Injectable({
    providedIn: 'root'
})
export class BooksClient implements IBooksClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ?? "";
    }

    getBooksWithPagination(searchCriteria: string | null, pageNumber: number, pageSize: number): Observable<PaginatedListOfBookDto> {
        let url_ = this.baseUrl + "/api/Books?";
        if (searchCriteria === undefined)
            throw new Error("The parameter 'searchCriteria' must be defined.");
        else if(searchCriteria !== null)
            url_ += "SearchCriteria=" + encodeURIComponent("" + searchCriteria) + "&";
        if (pageNumber === undefined || pageNumber === null)
            throw new Error("The parameter 'pageNumber' must be defined and cannot be null.");
        else
            url_ += "PageNumber=" + encodeURIComponent("" + pageNumber) + "&";
        if (pageSize === undefined || pageSize === null)
            throw new Error("The parameter 'pageSize' must be defined and cannot be null.");
        else
            url_ += "PageSize=" + encodeURIComponent("" + pageSize) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetBooksWithPagination(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetBooksWithPagination(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<PaginatedListOfBookDto>;
                }
            } else
                return _observableThrow(response_) as any as Observable<PaginatedListOfBookDto>;
        }));
    }

    protected processGetBooksWithPagination(response: HttpResponseBase): Observable<PaginatedListOfBookDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = PaginatedListOfBookDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    createBook(command: CreateBookCommand): Observable<number> {
        let url_ = this.baseUrl + "/api/Books";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreateBook(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreateBook(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<number>;
                }
            } else
                return _observableThrow(response_) as any as Observable<number>;
        }));
    }

    protected processCreateBook(response: HttpResponseBase): Observable<number> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    updateBook(id: number, command: UpdateBookCommand): Observable<void> {
        let url_ = this.baseUrl + "/api/Books?";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined and cannot be null.");
        else
            url_ += "id=" + encodeURIComponent("" + id) + "&";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdateBook(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateBook(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<void>;
                }
            } else
                return _observableThrow(response_) as any as Observable<void>;
        }));
    }

    protected processUpdateBook(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return _observableOf(null as any);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    deleteBook(id: number): Observable<void> {
        let url_ = this.baseUrl + "/api/Books/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteBook(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteBook(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<void>;
                }
            } else
                return _observableThrow(response_) as any as Observable<void>;
        }));
    }

    protected processDeleteBook(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return _observableOf(null as any);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export class PaginatedListOfBookDto implements IPaginatedListOfBookDto {
    items?: BookDto[];
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasPreviousPage?: boolean;
    hasNextPage?: boolean;

    constructor(data?: IPaginatedListOfBookDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(BookDto.fromJS(item));
            }
            this.pageNumber = _data["pageNumber"];
            this.totalPages = _data["totalPages"];
            this.totalCount = _data["totalCount"];
            this.hasPreviousPage = _data["hasPreviousPage"];
            this.hasNextPage = _data["hasNextPage"];
        }
    }

    static fromJS(data: any): PaginatedListOfBookDto {
        data = typeof data === 'object' ? data : {};
        let result = new PaginatedListOfBookDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        data["pageNumber"] = this.pageNumber;
        data["totalPages"] = this.totalPages;
        data["totalCount"] = this.totalCount;
        data["hasPreviousPage"] = this.hasPreviousPage;
        data["hasNextPage"] = this.hasNextPage;
        return data;
    }
}

export interface IPaginatedListOfBookDto {
    items?: BookDto[];
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasPreviousPage?: boolean;
    hasNextPage?: boolean;
}

export class BookDto implements IBookDto {
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;

    constructor(data?: IBookDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.title = _data["title"];
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.totalCopies = _data["totalCopies"];
            this.copiesInUse = _data["copiesInUse"];
            this.type = _data["type"];
            this.isbn = _data["isbn"];
            this.category = _data["category"];
        }
    }

    static fromJS(data: any): BookDto {
        data = typeof data === 'object' ? data : {};
        let result = new BookDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["title"] = this.title;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["totalCopies"] = this.totalCopies;
        data["copiesInUse"] = this.copiesInUse;
        data["type"] = this.type;
        data["isbn"] = this.isbn;
        data["category"] = this.category;
        return data;
    }
}

export interface IBookDto {
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;
}

export class CreateBookCommand implements ICreateBookCommand {
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;

    constructor(data?: ICreateBookCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.title = _data["title"];
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.totalCopies = _data["totalCopies"];
            this.copiesInUse = _data["copiesInUse"];
            this.type = _data["type"];
            this.isbn = _data["isbn"];
            this.category = _data["category"];
        }
    }

    static fromJS(data: any): CreateBookCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateBookCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["title"] = this.title;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["totalCopies"] = this.totalCopies;
        data["copiesInUse"] = this.copiesInUse;
        data["type"] = this.type;
        data["isbn"] = this.isbn;
        data["category"] = this.category;
        return data;
    }
}

export interface ICreateBookCommand {
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;
}

export class UpdateBookCommand implements IUpdateBookCommand {
    bookId?: number;
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;

    constructor(data?: IUpdateBookCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.bookId = _data["bookId"];
            this.title = _data["title"];
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.totalCopies = _data["totalCopies"];
            this.copiesInUse = _data["copiesInUse"];
            this.type = _data["type"];
            this.isbn = _data["isbn"];
            this.category = _data["category"];
        }
    }

    static fromJS(data: any): UpdateBookCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateBookCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["bookId"] = this.bookId;
        data["title"] = this.title;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["totalCopies"] = this.totalCopies;
        data["copiesInUse"] = this.copiesInUse;
        data["type"] = this.type;
        data["isbn"] = this.isbn;
        data["category"] = this.category;
        return data;
    }
}

export interface IUpdateBookCommand {
    bookId?: number;
    title?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    totalCopies?: number;
    copiesInUse?: number;
    type?: string | undefined;
    isbn?: string | undefined;
    category?: string | undefined;
}

export class SwaggerException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}