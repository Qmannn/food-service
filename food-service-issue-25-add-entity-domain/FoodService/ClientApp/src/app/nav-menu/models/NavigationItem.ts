export class NavigationItem {
    private readonly _name: string;
    private readonly _link: string;
    private readonly _icon: string;

    public constructor(name: string, link: string, icon: string) {
        this._name = name;
        this._link = link;
        this._icon = icon;
    }

    public get name(): string {
        return this._name;
    }

    public get link(): string {
        return this._link;
    }

    public get icon(): string {
        return this._icon;
    }
}
