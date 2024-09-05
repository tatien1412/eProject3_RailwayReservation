"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.generate = exports.PAPER_DASHBOARD = exports.MATERIAL = exports.BOOTSTRAP = void 0;
const schematics_1 = require("@angular-devkit/schematics");
const core_1 = require("@angular-devkit/core");
const JSON5 = require("json5");
const crudModelUtils = require("../utils/crud-model-utils");
const strings_1 = require("@angular-devkit/core/src/utils/strings");
const workspace_1 = require("@schematics/angular/utility/workspace");
const schematics_2 = require("@angular/cdk/schematics");
exports.BOOTSTRAP = 'bootstrap';
exports.MATERIAL = 'material';
exports.PAPER_DASHBOARD = 'paper-dashboard';
function getFramework(host) {
    let possibleFiles = ['/package.json'];
    const path = possibleFiles.filter(path => host.exists(path))[0];
    const configBuffer = host.read(path);
    if (configBuffer === null) {
        throw new schematics_1.SchematicsException(`Could not find (${path})`);
    }
    else {
        const content = JSON.parse(configBuffer.toString());
        if (content.dependencies['bootstrap']) {
            return exports.BOOTSTRAP;
        }
        else if (content.dependencies['@angular/material']) {
            return exports.MATERIAL;
        }
        else {
            return exports.PAPER_DASHBOARD;
        }
    }
}
function generate(options) {
    return (host) => __awaiter(this, void 0, void 0, function* () {
        // allow passing the CSS framework in (for testing)
        let cssFramework = options.style;
        // if no CSS framework defined, try to detect it
        // defaults to paper-dashboard if nothing found (for backward compatibility)
        if (!cssFramework) {
            cssFramework = getFramework(host);
        }
        const workspace = yield (0, workspace_1.getWorkspace)(host);
        if (!options.project) {
            options.project = workspace.projects.keys().next().value;
        }
        const project = workspace.projects.get(options.project);
        const appPath = `${project === null || project === void 0 ? void 0 : project.sourceRoot}/app`;
        const modelFile = `${appPath}/${options.name}/${options.model}`;
        const modelBuffer = host.read(modelFile);
        if (modelBuffer === null) {
            throw new schematics_1.SchematicsException(`Model file ${options.model} does not exist.`);
        }
        const modelJson = modelBuffer.toString('utf-8');
        const model = JSON5.parse(modelJson);
        // add imports to app.module.ts
        (0, schematics_2.addModuleImportToModule)(host, `${appPath}/app.module.ts`, `${(0, strings_1.capitalize)(model.entity)}Module`, `./${options.name}/${model.entity}.module`);
        const templateSource = (0, schematics_1.apply)((0, schematics_1.url)(`./files/${cssFramework}`), [
            (0, schematics_1.template)(Object.assign(Object.assign(Object.assign(Object.assign({}, core_1.strings), options), crudModelUtils), { model })),
            (0, schematics_1.move)(`${appPath}/${options.name}`),
        ]);
        return (0, schematics_1.mergeWith)(templateSource, schematics_1.MergeStrategy.Overwrite);
    });
}
exports.generate = generate;
//# sourceMappingURL=index.js.map