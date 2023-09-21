export interface UserSetting {
    id: string;
    userId: string;
    key: string;
    value: string;
}

export interface UserContent {
    id: string;
    author: string;
    title: string;
    type: string;
    size: number;
    url: string;
    dateOfCreation: string;
}

export interface UserContentsInfo {
    count: number;
    countToday: number;
}
