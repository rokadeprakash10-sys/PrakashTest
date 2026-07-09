---
applyTo: "**"
description: "Use when the user clicks Fix Issue, asks to fix a specific error, or requests automatic issue navigation and remediation."
---

# Fix Issue Workflow

When the user asks to fix an issue, follow this exact sequence:

1. Identify the concrete failing signal first.
- Gather diagnostics from compiler/linter errors, failing tests, runtime stack traces, or explicit user repro steps.
- If no concrete error exists, do not guess. Ask for a reproducible error signal.

2. Navigate to the exact failure location.
- Open the file and line where the error is reported.
- If the error is indirect, trace to the owning source location before editing.

3. Analyze root cause before changing code.
- Determine why the failure occurs in this code path.
- Confirm assumptions with nearby code, related types, and call sites.

4. Apply a focused fix for this specific issue.
- Change the minimum code required in the true source location.
- Avoid unrelated refactors or formatting-only churn.

5. Validate the fix immediately.
- Re-run the smallest relevant test/build command that proves the issue is resolved.
- If possible, also run one nearby regression check.

6. Report outcome with evidence.
- State what failed, where it failed, what was changed, and what passed after the fix.
- Include any residual risks or follow-up items.

## Guardrails

- Prefer precise edits over broad rewrites.
- Do not change public behavior beyond what is needed to resolve the issue.
- If multiple independent errors exist, fix only the user-requested issue unless asked otherwise.
