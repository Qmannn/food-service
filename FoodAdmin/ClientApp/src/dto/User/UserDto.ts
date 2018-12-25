import { UserRole } from './Enum/UserRole';

export class UserDto {
    public id: number;
    public name: string;
    public role: UserRole;
}